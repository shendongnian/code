    public string RequestPage(string url)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Timeout = 10000;
        using (WebResponse resp = req.GetResponse())
        using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
        {
            return reader.ReadToEnd();
        }
    }
