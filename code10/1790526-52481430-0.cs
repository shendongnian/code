    public static string HttpPost(string URI, string Parameters)
    {
        System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
    
        req.ContentType = "application/json; charset=utf-8";
        req.Method = "POST";
        req.Timeout = 600000;
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
        req.ContentLength = bytes.Length;
        System.IO.Stream os = req.GetRequestStream();
        os.Write(bytes, 0, bytes.Length);
        os.Close();
        System.Net.WebResponse resp = req.GetResponse();
        if (resp == null)
            return null;
        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
        return sr.ReadToEnd().Trim();
    }
