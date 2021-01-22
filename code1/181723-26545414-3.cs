    IList<int> test = new List<int>();
    for(int i = 0; i<1000000; i++)
    {
        test.Add(i);
    }
            
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    IList<int> result = TakeLast(test, 10).ToList();
    stopwatch.Stop();
    Stopwatch stopwatch1 = new Stopwatch();
    stopwatch1.Start();
    IList<int> result1 = TakeLast2(test, 10).ToList();
    stopwatch1.Stop();
    Stopwatch stopwatch2 = new Stopwatch();
    stopwatch2.Start();
    IList<int> result2 = test.Skip(Math.Max(0, test.Count - 10)).Take(10).ToList();
    stopwatch2.Stop();
