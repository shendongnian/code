    DispatcherTimer timer;
    ulong bytesReceivedAtLastTick;
    
    private async void StartDownload()
    {
        BackgroundDownloader downloader = new BackgroundDownloader();
        DownloadOperation download = downloader.CreateDownload(source, destinationFile);
        timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += (s, e) => {
            var bytesReceivedAtThisTick = download.Progress.BytesReceived;
            var bytesPerSecond = bytesReceivedAtThisTick - bytesReceivedAtLastTick;
            Log($"Download speed: {bytesPerSecond} B/s");
            bytesReceivedAtLastTick = bytesReceivedAtThisTick;
        };
        timer.Start();
        await download.StartAsync().AsTask(cts.Token, progressCallback);
    }
