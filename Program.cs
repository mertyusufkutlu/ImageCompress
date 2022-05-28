using System;
using System.Collections.Generic;
using ImageMagick;

namespace ConsoleAppPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> urls = new List<string>();
            urls.Add("https://cutewallpaper.org/21/macbook-wallpaper-4k/2880x1800-Beautiful-London-City-View-8k-Macbook-Pro-Retina-.jpg");
            Run(urls);
        }
        private static void Run(List<string> urls)
        {
            List <Response> list = new List<Response>();
            foreach (var url in urls)
            {
                using (MagickImage image = new MagickImage(url))
                {
                    image.Format = image.Format; // Get or Set the format of the image.
                    // image.Resize(40, 40); // fit the image into the requested width and height. 
                    image.Quality = 50; // This is the Compression level.
                    //todo: byte array'e cevirelecek
                    // image.Write("");
                    list.Add(new Response()
                    {
                        ImageData = image.ToByteArray(),
                        Url = url
                    });
                }
                
            }
            
        }
        public class Response
        {
            public string Url { get; set; }
            public byte[] ImageData { get; set; }
        }
        
    }

}