    ShallowCloneTest t1 = new ShallowCloneTest() { Bar = 1, Foo = 2 };
    Stopwatch sw = Stopwatch.StartNew();
    int total = 0;
    for (int i = 0; i < 10000000; ++i)
    {
        var cloned = t1.Clone();                                    // 0.40s
        total += cloned.Foo;
    }
    Console.WriteLine("Took {0:0.00}s", sw.Elapsed.TotalSeconds);
