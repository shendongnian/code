    var arrays = new byte[100000000][];
    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
    stopwatch.Start();
    for (var i = 0; i<100000000; i++)
    {
        arrays[i] = new byte[50];
    }
    stopwatch.Stop();
    Console.WriteLine($"initially allocating arrays took {stopwatch.ElapsedMilliseconds} ms");
    stopwatch.Restart();
    GC.Collect();
    Console.WriteLine($"GC after array allocation took {stopwatch.ElapsedMilliseconds} ms");
    Dictionary<int, byte[]> dict = new Dictionary<int, byte[]>(100000000);
    //Dictionary<int, byte[]> dict = new Dictionary<int, byte[]>();
    for (var c = 0; c < 100; c++)
    {
        stopwatch.Restart();
        for (var i = 0; i < 1000000; i++)
        {
            var thing = new AThing();
            dict.Add((c * 1000000) + i, arrays[(c*100000)+i]);
        }
        stopwatch.Stop();
        Console.WriteLine($"pass number {c} took {stopwatch.ElapsedMilliseconds} milliseconds");
    }
    Console.ReadLine();
