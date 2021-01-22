    public string RequestPage(string url)
    {
        var req = (HttpWebRequest)WebRequest.Create(url);
        req.Timeout = 10000;
        using (var resp = req.GetResponse())
        using (var reader = new StreamReader(resp.GetResponseStream()))
        {
            return reader.ReadToEnd();
        }
    }
