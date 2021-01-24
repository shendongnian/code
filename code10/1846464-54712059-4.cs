    async Task ExecuteEvery(TimeSpan ts, Action a, CancellationToken ct)
    {
        try
        {
            for (var targetTime = DateTime.Now + ts; !ct.IsCancellationRequested; targetTime += ts)
            {
                var timeToWait = targetTime - DateTime.Now;
                if (timeToWait > TimeSpan.Zero)
                    await Task.Delay(timeToWait, ct);
                a();
            }
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested)
        {
            // if we are cancelled, nothing to do, just exit
        }
    }
