    Public static Task DownloadToCacheAsync()
    {
        return Task.Run(()=>DownloadToCache());
    }
    Public static void DownloadToCache()
    {
        DownloadToCacheAsync().Wait();
    }
