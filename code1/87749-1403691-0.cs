    using System;
    using System.Net;
    
    class Test
    {
        static void Main()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
            request.Timeout = 1000;
            
            try
            {
                using (var response = request.GetResponse()) {}
                Console.WriteLine("Success");
            }
            catch (WebException)
            {
                Console.WriteLine("No connection");
            }
        }
    }
