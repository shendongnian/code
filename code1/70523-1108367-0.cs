    private void StartDownload()
    {
    
        // Create a new WebClient instance.
        WebClient myWebClient = new WebClient();
            
        // Set the progress bar max to 100 for 100%
        progressBar1.Value = 0;
        progressBar1.Maximum = 100;
            
        // Assign the events to capture the progress percentage
        myWebClient.DownloadDataCompleted+=new DownloadDataCompletedEventHandler(myWebClient_DownloadDataCompleted);
        myWebClient.DownloadProgressChanged+=new DownloadProgressChangedEventHandler(myWebClient_DownloadProgressChanged);
            
        // Set the Uri to the file you wish to download and fire it off Async
        Uri uri = new Uri("http://external.ivirtualdocket.com/update.cab");
        myWebClient.DownloadFileAsync(uri, "C:\\Update.cab");
    
    }
    
    void myWebClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }
    
    void myWebClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        progressBar1.Value = progressBar1.Maximum;
    }
