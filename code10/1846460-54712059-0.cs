    async Task ExecuteEvery(TimeSpan ts, Action a, CancellationToken ct)
    {
        try
        {
            var currentDelay = Task.Delay(ts, ct);
            while (!ct.IsCancellationRequested)
            {
                await currentDelay;
                currentDelay = Task.Delay(ts);
                a();
            }
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested)
        {
        }
    }
