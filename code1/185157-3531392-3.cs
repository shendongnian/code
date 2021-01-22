    public string RequestPage(string url)
    {
        using (WebClient client = new WebClient())
        {
            return client.DownloadString(url);
        }
    }
