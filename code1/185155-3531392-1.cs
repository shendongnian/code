    public string RequestPage(string url)
    {
        using (var client = new WebClient())
        {
            return client.DownloadString(url);
        }
    }
