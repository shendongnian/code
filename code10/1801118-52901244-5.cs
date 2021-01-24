       var ms = 5000;
       Console.WriteLine("Start " + DebugInfo);
       var list = Enumerable.Range(0, 10).Select(x => SleepAsyncA(ms));
    
       Task.WaitAll(list.ToArray());
    
       var list2 = Enumerable.Range(0, 10).Select(x => SleepAsyncB(ms));
       Task.WaitAll(list2.ToArray());
