    // Max concurrency: 43
    [Test]
    public void Test()
    {
        ConcurrentBag<int> monitor = new ConcurrentBag<int>();
        ConcurrentBag<int> monitorOut = new ConcurrentBag<int>();
        var arrayStrings = new string[1000];
        var options = new ParallelOptions {MaxDegreeOfParallelism = int.MaxValue};
        Parallel.ForEach<string>(arrayStrings, options, someString =>
        {
            monitor.Add(monitor.Count);
    
            System.Threading.Thread.Sleep(1000);
    
            monitor.TryTake(out int result);
            monitorOut.Add(result);
        });
                
        Console.WriteLine("Max concurrency: " + monitorOut.OrderByDescending(x => x).First());
    }
    // Max concurrency: 391
    [Test]
    public void Test()
    {
        ConcurrentBag<int> monitor = new ConcurrentBag<int>();
        ConcurrentBag<int> monitorOut = new ConcurrentBag<int>();
        var arrayStrings = new string[1000];
        var options = new ParallelOptions {MaxDegreeOfParallelism = int.MaxValue};
        Parallel.ForEach<string>(arrayStrings, options, someString =>
        {
            monitor.Add(monitor.Count);
    
            System.Threading.Thread.Sleep(100000);
    
            monitor.TryTake(out int result);
            monitorOut.Add(result);
        });
                
        Console.WriteLine("Max concurrency: " + monitorOut.OrderByDescending(x => x).First());
    }
