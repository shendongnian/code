        static void Main(string[] args)
        {
            string result = SendPost(@"C:\Test1.txt", "https://httpbin.org/post");
            if(result.Contains("SUCCESS"))
                SendPost(@"C:\Test2.txt", "https://httpbin.org/anotherpost");
        }
        static string SendPost(string filename, string URL)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "text/plain";
            httpWebRequest.Method = "POST";
            /*proxy config*/
            WebProxy proxy = new WebProxy();
            Uri newUri = new Uri("http://xxxxxx");
            proxy.Address = newUri;
            httpWebRequest.Proxy = proxy;
            using (var sw = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string[] lines = File.ReadAllLines(filename);
                for(int i=0; i<lines.Length; i++)
                    sw.WriteLine(lines[i]);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }
