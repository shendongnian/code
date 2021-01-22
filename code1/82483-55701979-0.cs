    private static CancellationTokenSource StressCPU(int percent)
    {
        if (percent < 0 || percent > 100) throw new ArgumentException(nameof(percent));
        var cts = new CancellationTokenSource();
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            new Thread(() =>
            {
                var stopwatch = new Stopwatch();
                while (!cts.IsCancellationRequested)
                {
                    stopwatch.Restart();
                    while (stopwatch.ElapsedMilliseconds < percent) { } // hard work
                    Thread.Sleep(100 - percent); // chill out
                }
            }).Start();
        }
        return cts;
    }
