    var ints = Enumerable.Range(0, 10000000).ToList();
    var sw1 = Stopwatch.StartNew();
    var findall = ints.FindAll(i => i % 2 == 0);
    sw1.Stop();
    var sw2 = Stopwatch.StartNew();
    var where = ints.Where(i => i % 2 == 0).ToList();
    sw2.Stop();
    Console.WriteLine("sw1: {0}", sw1.ElapsedTicks);
    Console.WriteLine("sw2: {0}", sw2.ElapsedTicks);
    /*
    Debug
    sw1: 1149856
    sw2: 1652284
    Release
    sw1: 532194
    sw2: 1016524
    */
