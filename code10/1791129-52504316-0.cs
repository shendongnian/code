    static void Main(string[] args)
    {
        var unrelatedList = new List<int>(1) { 1 };
        var jitMe = unrelatedList.IndexOf(1);
        var sw = Stopwatch.StartNew();
        sw.Stop();
        Console.WriteLine($"Initialized {jitMe}, {sw.Elapsed.TotalMilliseconds}");
        Console.WriteLine();
        const int k = 1000 * 1000;
        var l = new List<int>(k);
        for (var i = 0; i < k; i++)
        {
            l.Add(i);
        }
        for (var i = 0; i < 10; i++)
        {
            sw = Stopwatch.StartNew();
            var itm = l.IndexOf(0);
            sw.Stop();
            Console.WriteLine($"TotalMilliseconds: {sw.Elapsed.TotalMilliseconds}, {itm}");
        }
        Console.WriteLine("Done");
        Console.ReadLine();
    }
