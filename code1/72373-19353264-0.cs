    private readonly CancellationTokenSource cancellationTokenSource = 
        new CancellationTokenSource();
    private void Run()
    {
        while (!cancellationTokenSource.IsCancellationRequested)
        {
            DoWork();
            cancellationTokenSource.Token.WaitHandle.WaitOne(
                TimeSpan.FromMinutes(15));
        }
    }
    public void Stop()
    {
        cancellationTokenSource.Cancel();
    }
