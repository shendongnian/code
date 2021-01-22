    static void Test()
    {
        var rnd = new Random((int)System.DateTime.Now.ToFileTime());
        byte[] data = new byte[8192];
        rnd.NextBytes(data);
        byte[] copy = new byte[8192];
        data.CopyTo(copy, 0);
        SwapX2(data);
        Swap2(data);
        for (var i = 0; i < data.Length; i++)
        {
            if (data[i] != copy[i])
            {
                Console.WriteLine("err");
            }
        }
        for (var j = 0; j < 5; j++)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                SwapX2(data);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
        for (var j = 0; j < 5; j++)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                Swap2(data);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
