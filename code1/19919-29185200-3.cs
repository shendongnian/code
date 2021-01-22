    private void BtnDownload_Click(object sender, RoutedEventArgs e)
    {
        using (WebClient wc = new WebClient())
        {
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileAsync (
                // Param1 = Link of file
                new System.Uri("http://www.sayka.com/downloads/front_view.jpg"),
                // Param2 = Path to save
                "D:\\Images\\front_view.jpg"
            );
        }
    }
    // Event to track the progress
    void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        progressBar.Value = e.ProgressPercentage;
    }
