     static void Test()
     {
        string[] results = new string[5];
        var rnd = new Random((int)System.DateTime.Now.ToFileTime());
        byte[] data = new byte[8192]; // Change to 8193 and see the "bug" in SwapX2
        rnd.NextBytes(data);
        byte[] copy = new byte[8192];
        data.CopyTo(copy, 0);
        // Swap with SwapX2, swap back with SwapV2
        SwapX2(data);
        SwapV2(data);
        // Still equal?
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
            results[j] = watch.ElapsedMilliseconds.ToString();
        }
        Console.WriteLine("SwapX2: " + String.Join(", ", results));
        for (var j = 0; j < 5; j++)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                SwapV2(data);
            }
            watch.Stop();
            results[j] = watch.ElapsedMilliseconds.ToString();
        }
        Console.WriteLine("SwapV2: " + String.Join(", ", results));
    }
