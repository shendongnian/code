    static void Test()
    {
        // Change to 8193 and see the "bug" in SwapX2
        const int SIZE = 8192;
        const int LOOPS = 300000;
        const int TESTS = 5;
        string[] results = new string[TESTS];
        var rnd = new Random((int)System.DateTime.Now.ToFileTime());
        byte[] data = new byte[SIZE]; 
        byte[] copy = new byte[data.Length];
        // Create random data, and a copy...
        rnd.NextBytes(data);
        data.CopyTo(copy, 0);
        // Swap with SwapX2, swap back with SwapV2
        SwapX2(data);
        SwapV2(data);
        // Still equal?
        for (var i = 0; i < SIZE; i++)
        {
            if (data[i] != copy[i])
            {
                Console.WriteLine("err");
            }
        }
        for (var j = 0; j < TESTS; j++)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < LOOPS; i++)
            {
                SwapV2(data);
            }
            watch.Stop();
            results[j] = watch.ElapsedMilliseconds.ToString();
        }
        Console.WriteLine("SwapV2: " + String.Join(", ", results));
        for (var j = 0; j < TESTS; j++)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < LOOPS; i++)
            {
                SwapX2(data);
            }
            watch.Stop();
            results[j] = watch.ElapsedMilliseconds.ToString();
        }
        Console.WriteLine("SwapX2: " + String.Join(", ", results));
    }
