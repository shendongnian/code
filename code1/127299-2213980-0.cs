    void DownloadUpdates()
    {
        ThreadPool.QueueUserWorkItem(state =>
            for(int i = 0; i < 10; i++)
            {
                webClient.UploadFileAsync(uri, "PUT", fileNameOnHD);
                while(!downloadComplete) { Thread.Sleep(1); }
            });
    }
