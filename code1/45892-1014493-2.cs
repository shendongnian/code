    private static string WebRequestPostData(string url, string postData)
    {
        System.Net.WebRequest req = System.Net.WebRequest.Create(url);
        req.ContentType = "text/xml";
        req.Method = "POST";
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(postData);
        req.ContentLength = bytes.Length;
        using (Stream os = req.GetRequestStream())
        {
            os.Write(bytes, 0, bytes.Length);
        }
        using (System.Net.WebResponse resp = req.GetResponse())
        {
            if (resp == null) return null;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
            {
                return sr.ReadToEnd().Trim();
            }
        }
    }
