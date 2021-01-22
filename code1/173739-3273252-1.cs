    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = WebRequest.Create("http://google.com") as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            WebHeaderCollection header = response.Headers;
            var buf = new byte[1024];
            var sb = new StringBuilder();
            var resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;
            do
            {
                // fill the buffer with data
                count = resStream.Read(buf, 0, buf.Length);
                // make sure we read some data
                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    tempString = Encoding.ASCII.GetString(buf, 0, count);
                    // continue building the string
                    sb.Append(tempString);
                }
            }
            while (count > 0); // any more data to read?
            // print out page source
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
