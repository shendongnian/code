    async Task ExecuteEvery(TimeSpan ts, Action a, CancellationToken ct)
    {
        try
        {
            var currentDelay = Task.Delay(ts, ct);
            while (!ct.IsCancellationRequested)
            {
                await currentDelay; // waiting for the timeout
                currentDelay = Task.Delay(ts, ct); // timeout finished, starting next wait
                a(); // executing action in the meanwhile
            }
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested)
        {
            // if we are cancelled, nothing to do, just exit
        }
    }
