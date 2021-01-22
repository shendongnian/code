    var dm = DownloadManager
    {
        "http://google.com",
        new DownloadItem("http://yahoo.com") { Retries = 5 }
    };
    dm.ProgressChanged += (sender, e) =>
        Console.WriteLine("Download {0}: {1:P}", e.Uri, (double)e.Progress / 100.0);
    dm.DownloadCompleted += (sender, e) =>
        Console.WriteLine("Download {0}: completed!", e.Uri);
    dm.DownloadAllCompleted += (sender, e) =>
        Console.WriteLine("All downloads completed!");
    dm.Add("http://stackoverflow.com");
    dm.DownloadAllAsync();
