    for (int x = 0; x < 20; x++)
    {
        var ints = Enumerable.Range(0, 10000000).ToList();
        var sw1 = Stopwatch.StartNew();
        var findall = ints.FindAll(i => i % 2 == 0).Count;
        sw1.Stop();
        var sw2 = Stopwatch.StartNew();
        var where = ints.AsEnumerable().Where(i => i % 2 == 0).Count();
        sw2.Stop();
       
        var sw4 = Stopwatch.StartNew();
        var cntForeach = 0;
        foreach (var item in ints)
            if (item % 2 == 0)
                cntForeach++; 
        sw4.Stop();
        Console.WriteLine("sw1: {0}", sw1.ElapsedTicks);
        Console.WriteLine("sw2: {0}", sw2.ElapsedTicks);
        Console.WriteLine("sw4: {0}", sw4.ElapsedTicks);
    }
    /* averaged results
    sw1	575446.8
    sw2	605954.05
    sw3	394506.4
    /*
