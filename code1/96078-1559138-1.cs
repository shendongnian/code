    public Setup(DiscoveryReader reader)
    {
        download = new DownloadFilesIndividual(Reader.ip, DateTime.Today);
        download.OnDownloadStatus += new DownloadStatusHandler(download_OnDownloadStatus);
    }
    void download_OnDownloadStatus(DownloadStatus status)
    {
       if(InvokeRequired)
       {
        Invoke(new Action<DownloadStatus>(download_OnDownloadStatus),status);
       } else {
       // Do UI stuff here
       }
    }
