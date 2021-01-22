    public static void DownloadFile(string remoteFilename, string localFilename)
    {
        WebClient client = new WebClient();
        client.DownloadFile(remoteFilename, localFilename);
    }
