    using(var cts = new CancellationTokenSource(5000))
    {
        try
        {
            await WhenFileCreated(string path, cts.Token);
        }
        catch(TaskCanceledException)
        {
            //...
        }
    }
