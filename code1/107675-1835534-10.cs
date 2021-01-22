    using (var ctx = CreateContext()) {
        // show sample query
        ctx.Log = Console.Out;
        Console.WriteLine(ctx.GetRandomUrl());
        ctx.Log = null;
        // check distribution
        var counts = new Dictionary<string, int>();
        for (int i = 0; i < 11000; i++) // obviously a bit slower than inside db
        {
            if (i % 100 == 1) Console.WriteLine(i); // show progress
            string s = ctx.GetRandomUrl();
            int count;
            if (counts.TryGetValue(s, out count)) {
                counts[s] = count + 1;
            } else {
                counts[s] = 1;
            }
        }
        Console.WriteLine("(total)\t{0}", counts.Sum(p => p.Value));
        foreach (var pair in counts.OrderBy(p => p.Key)) {
            Console.WriteLine("{0}\t{1}", pair.Key, pair.Value);
        }
    }
