    public byte[] GetFileViaHttp(string url)
    {
        using (WebClient client = new WebClient())
        {
            return client.DownloadData(url);
        }
    }
