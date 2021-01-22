    using System;
    using System.Net;
    static class Program
    {
        static void Main()
        {
            using (MyClient client = new MyClient())
            {
                client.HeadOnly = true;
                string uri = "http://www.google.com";
                byte[] body = client.DownloadData(uri); // note should be 0-length
                string type = client.ResponseHeaders["content-type"];
                client.HeadOnly = false;
                // check 'tis not binary... we'll use text/, but could
                // check for text/html
                if (type.StartsWith(@"text/"))
                {
                    string text = client.DownloadString(uri);
                    Console.WriteLine(text);
                }
            }
        }
    
    }
    
    class MyClient : WebClient
    {
        public bool HeadOnly { get; set; }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest req = base.GetWebRequest(address);
            if (HeadOnly && req.Method == "GET")
            {
                req.Method = "HEAD";
            }
            return req;
        }
    }
