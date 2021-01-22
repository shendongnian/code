    public string[] SearchForMovie(string SearchParameter)
    {
        WebClientX.DownloadDataCompleted += WebClientX_DownloadDataCompleted;
        WebClientX.DownloadDataAsync(new Uri(uri));
    }
    void WebClientX_DownloadDataCompleted(object sender,
         DownloadDataCompletedEventArgs e)
    {
        Buffer = e.Result;
        string sitesearchSource = Encoding.ASCII.GetString(Buffer);
    }
