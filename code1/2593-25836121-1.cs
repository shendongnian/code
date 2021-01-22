    PerformWork();
    int repeat = 1000;
    Stopwatch sw = Stopwatch.StartNew();
    for (int i = 0; I < repeat; i ++)
    {
       PerformWork();
    }
    sw.Stop();
    Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds / repeat);
