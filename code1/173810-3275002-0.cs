    class Program
    {
        static void Main()
        {
            var data = new List<KeyValuePair<string, string>>(new[]
            {
                new KeyValuePair<string, string>("list", "8274184"),
                new KeyValuePair<string, string>("list", "8274174"),
                new KeyValuePair<string, string>("list", "8274178"),
                new KeyValuePair<string, string>("antirobot", "2341234"),
                new KeyValuePair<string, string>("votehidden", "1"),
            });
    
            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
    
            var request = (HttpWebRequest)WebRequest.Create("http://example.com");
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
    
            using (var requestStream = request.GetRequestStream())
            using (var writer = new StreamWriter(requestStream))
            {
                foreach (var item in data)
                {
                    writer.WriteLine(boundary);
                    writer.WriteLine(string.Format("Content-Disposition: form-data; name=\"{0}\"", item.Key));
                    writer.WriteLine();
                    writer.WriteLine(item.Value);
                }
                writer.WriteLine(boundary + "--");
            }
    
            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
