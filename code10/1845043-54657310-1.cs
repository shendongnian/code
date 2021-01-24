    var lookup = new RangeLookup();
    
    for (var i = 1; i <= 10000000; i++)
    {
        var max = i * 100;
        var min = max - 99;
        lookup.Add((min, max), $"In {min}-{max}s");
    }
    
    var stopwatch = new Stopwatch();
    
    stopwatch.Start();
    Console.WriteLine($"50: {lookup[50]} (TimeToLookup: {stopwatch.ElapsedMilliseconds})");
    
    stopwatch.Restart();
    Console.WriteLine($"5,000: {lookup[5000]} (TimeToLookup: {stopwatch.ElapsedMilliseconds})");
    
    stopwatch.Restart();
    Console.WriteLine($"1,000,000,000: {lookup[1000000000]} (TimeToLookup: {stopwatch.ElapsedMilliseconds})");
