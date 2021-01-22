    volatile downloadComplete;
    void DownloadUpdates()
    {
        ThreadPool.QueueUserWorkItem(state =>
            for(int i = 0; i < 10; i++)
            {
                downloadComplete = false;
                webClient.UploadFileAsync(uri, "PUT", fileNameOnHD);
                while(!downloadComplete) { Thread.Sleep(1); }
            });
    }
    Upload_Completed_callback()
    {
        downloadComplete = true;
    }
