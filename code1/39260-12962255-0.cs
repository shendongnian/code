    public static string GetHTMLBody(string url)
    {
        string htmlBody;
        using (WebClient client = new WebClient ())
        {
            htmlBody = client.DownloadString(url);
        }
        return htmlBody;
    }
