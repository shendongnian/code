    static void TestMethod<T>(T t)
    {
        CastTo<int>.From(t); //computes delegate once and stored in a static variable
        int value = 0;
        var watch = Stopwatch.StartNew();
        for (int i = 0; i < 10000000; i++) 
        {
            value = (int)(object)t; 
            // similarly value = CastTo<int>.From(t);
            // etc
        }
        watch.Stop();
        Console.WriteLine(watch.Elapsed.TotalMilliseconds);
    }
