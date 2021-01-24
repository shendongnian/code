    var results = new HashSet<(int X, int Y)>();
    object resultLockObj = new object();
    var rng = new Random(1);
    var sw = new Stopwatch();
    while (true)
    {
        results.Clear();
        sw.Restart();
        Parallel.For(0, 20000, i =>
        {
            var entry = new List<(int X, int Y)>(); // essentially, this is what's going on:
            var r = rng.Next(0, 3);                 // around 20k handlers return coordinates of pixels to redraw
            for (var j = 0; j < r; j++)             // sometimes there are null entries, sometimes 1, more often 2
            {                                       // all entries are added to concurrent bag
                entry.Add((i, j * j));
            }
            if (entry.Count == 0)
            {
                entry = null;
            }
            if (entry != null)
            {
                lock (resultLockObj)
                {
                    foreach (var x in entry)
                    {
                        results.Add(x);
                    }
                }
            }
        });
        var time = sw.ElapsedMilliseconds;
        Console.WriteLine($"Result count: {results.Count:00000}, time: {time:000}");
        //Thread.Sleep(1000);
    }
