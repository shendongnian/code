    private async Task ParentAsync()
    {
        TimeSpan timeSpan = TimeSpan.FromMilliseconds(10000);
        CancellationTokenSource cts = new CancellationTokenSource(timeSpan);
        await ExecuteAsync(cts);
        cts.Cancel(); // This will cause the execution to cancel.
    }
    private async Task ExecuteAsync(CancellationTokenSource cts)
    {
        await Task.Run(() =>
                    {
                        //This is a blocking call
                        Task.Delay(11002).Wait();
                    }, cts.Token);
    }
