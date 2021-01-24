      public static string httpPost(string url, string json)
        {
            string content = "";          
            byte[] bs;
            if (json != null && json != string.Empty)
            {
                bs = Encoding.UTF8.GetBytes(json);
            }
            else
            {
                bs = Encoding.UTF8.GetBytes(url);
            }
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            if (json != string.Empty)
                req.ContentType = "application/json";
            else
                req.ContentType = "application/x-www-form-urlencoded";
            req.KeepAlive = false;
            req.Timeout = 30000;
            req.ReadWriteTimeout = 30000;
            //req.UserAgent = "test.net";
            req.Accept = "application/json";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Flush();
                reqStream.Close();
            }
            using (WebResponse wr = req.GetResponse())
            {
                Stream s = wr.GetResponseStream();
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                content = reader.ReadToEnd();
                wr.Close();
                s.Close();
                reader.Close();
            }
            return content;
            
        }
