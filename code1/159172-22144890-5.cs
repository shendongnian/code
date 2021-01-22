    Stopwatch sw = new Stopwatch();
    List<Int64> test1list = new List<Int64>(), test2list = new List<Int64>();
    for (int j = 0; j < 100; j++)
    {
        sw.Start();
        for (int i = 0; i < 1000000; i++)
        {
            Test1 t = new Test1();
            if (!t.DoStuffAsync().IsCompleted)
                throw new Exception();
        }
        sw.Stop();
        test1list.Add(sw.ElapsedMilliseconds);
        
        sw.Reset();
        sw.Start();
        for (int i = 0; i < 1000000; i++)
        {
            Test2 t = new Test2();
            if (!t.DoStuffAsync().IsCompleted)
                throw new Exception();
        }
        sw.Stop();
        test2list.Add(sw.ElapsedMilliseconds);
        
        sw.Reset();
        GC.Collect();
    }
    Console.WriteLine("Test 1: " + test1list.Average().ToString() + "ms.");
    Console.WriteLine("Test 2: " + test2list.Average().ToString() + "ms.");
