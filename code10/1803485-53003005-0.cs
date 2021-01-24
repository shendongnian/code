    DispatcherTimer timer;
    ulong byteReceivedAtLastTick;
    
    private async void StartDownload()
    {
        BackgroundDownloader downloader = new BackgroundDownloader();
        DownloadOperation download = downloader.CreateDownload(source, destinationFile);
        timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += (s, e) => {
            var byteReceivedAtThisTick = download.Progress.BytesReceived;
            var speed = byteReceivedAtThisTick - byteReceivedAtLastTick;
            Log($"Download speed: {speed} B/s");
            byteReceivedAtLastTick = byteReceivedAtThisTick;
        };
        timer.Start();
        await download.StartAsync().AsTask(cts.Token, progressCallback);
    }
