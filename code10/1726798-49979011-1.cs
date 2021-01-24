    var sw = new Stopwatch();
    
    Random rand = new Random();
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Console.WriteLine("struct1");
    Console.WriteLine("Start   : {0:N0}", GC.GetTotalMemory(false));
    sw.Start();
    for (int i = 0; i < 100000000; i++)
    {
       _arrayOfTestStructs[rand.Next(100)] = new TestStruct();
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    sw.Reset();
    
    Console.WriteLine("Working : {0:N0}", GC.GetTotalMemory(false));
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Console.WriteLine("Collect : {0:N0}", GC.GetTotalMemory(false));
    Console.WriteLine("Class1");
    sw.Start();
    for (int i = 0; i < 100000000; i++)
    {
       _arrayOfTestClass[rand.Next(100)] = new TestClass();
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    sw.Reset();
    Console.WriteLine("Working : {0:N0}", GC.GetTotalMemory(false));
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Console.WriteLine("Collect : {0:N0}", GC.GetTotalMemory(false));
    Console.WriteLine("struct2");
    sw.Start();
    for (int i = 0; i < 100000000; i++)
    {
       _arrayOfTestStruct2[rand.Next(100)] = new TestStruct2();
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    sw.Reset();
    Console.WriteLine("Working : {0:N0}", GC.GetTotalMemory(false));
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Console.WriteLine("Collect : {0:N0}", GC.GetTotalMemory(false));
    Console.WriteLine("Class2");
    sw.Start();
    for (int i = 0; i < 100000000; i++)
    {
       _arrayOfTestClass2[rand.Next(100)] = new TestClass2();
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    sw.Reset();
    Console.WriteLine("Working : {0:N0}", GC.GetTotalMemory(false));
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Console.WriteLine("Collect : {0:N0}", GC.GetTotalMemory(false));
    Console.ReadKey();
