    private void BtnDownload_Click(object sender, RoutedEventArgs e)
    {
        using (WebClient wc = new WebClient())
        {
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileAsync(new System.Uri("http://www.sayka.in/downloads/front_view.jpg"),
            "D:\\Images\\front_view.jpg");
        }
    }
    void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        progressBar.Value = e.ProgressPercentage;
    }
