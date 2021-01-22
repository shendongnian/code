    private void downloadFile(string url)
    {
         string file = System.IO.Path.GetFileName(url);
         WebClient cln = new WebClient();
         cln.DownloadFile(url, file);
    }
