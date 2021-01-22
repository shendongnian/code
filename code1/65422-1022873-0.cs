    var req = WebRequest.Create(url);
    using (WebResponse resp = req.GetResponse())
    {
        using (Stream s = resp.GetResponseStream())
        {
            using (var sr = new StreamReader(s, Encoding.ASCII))
            {
                return sr.ReadToEnd();
            }
        }
    }
