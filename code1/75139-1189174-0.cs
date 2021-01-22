    using System;
    using System.IO;
    using System.Net;
    
    class Test
    {
        static void Main()
        {
            WebRequest request = WebRequest.Create("http://csharpindepth.com");
            using (WebResponse response = request.GetResponse())
            {
                Console.WriteLine(response.Headers["Content-Type"]);
                using (StreamReader reader = new StreamReader
                           (response.GetResponseStream()))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content.Substring(0, 120));
                }
            }
        }
    }
