    static void Main(string[] args)
    {
        const int TestIterations = 10000000;
        TimeSpan countTime = TestCounter(c => c.Count());
        Console.WriteLine("Count: {0}", countTime);
        TimeSpan countWithNewTime = TestCounter(c => c.CountWithNew());
        Console.WriteLine("CountWithNew: {0}", countWithNewTime);
        TimeSpan countSavedTime = TestCounter(c => c.CountSaved());
        Console.WriteLine("CountSaved: {0}", countSavedTime);
        Console.ReadLine();
    }
    static TimeSpan TestCounter(Action<Counter> action, int iterations)
    {
        var counter = new Counter();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < TestIterations; i++)
            action(counter);
        sw.Stop();
        return sw.Elapsed;
    }
