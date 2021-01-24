    static async Task SafeDelay(int delay, CancellationToken token)
    {
        try
        {
            await Task.Delay(delay, token);
        }
        catch (TaskCanceledException)
        {
        }
    }
    private static async Task Main()
    {
        //Set 1000 ms timeout
        var tokenSource = new CancellationTokenSource(1000);
        var stopwatch = Stopwatch.StartNew();
        var allTask = new List<Task>();
        Random r = new Random(9); 
        for (var i = 0; i < 1000; i++)
        {
            var randomDelay = r.Next(20000, 30000);
            allTask.Add(SafeDelay(randomDelay, tokenSource.Token));
        }
        Console.WriteLine($"All {allTask.Count} tasks running after {stopwatch.ElapsedMilliseconds} ms");
        await Task.WhenAll(allTask);
        stopwatch.Stop();
        Console.WriteLine($"Cancelation done after {stopwatch.ElapsedMilliseconds} ms");
    }
