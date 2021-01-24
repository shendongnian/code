    async Task Main()
    {
        // This async method call could also be an async lambda
        foreach (var task in GetNumbers().Select(WaitAndDoubleAsync))
        {
            var result = await task;
            Console.WriteLine($"Result is {result}");
            if (result > 5) break;
        }
    }
    
    private async Task<int> WaitAndDoubleAsync(int i)
    {
        Console.WriteLine($"Waiting {i} seconds asynchronously");
        await Task.Delay(TimeSpan.FromSeconds(i));
        return i * 2;
    }
    
    /// Keeps yielding numbers
    public IEnumerable<int> GetNumbers()
    {
        var i = 0;
        while (true) yield return i++;
    }
