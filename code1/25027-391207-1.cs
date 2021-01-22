    static  void Main()
    {
        GC.Collect(GC.MaxGeneration,GCCollectionMode.Forced);
        int count1 = 0;
        var watch1 = Stopwatch.StartNew();        
        for(int i = 0 ; i < 5000 ; i++) {
            foreach (var row in MyYieldCollection)
            {
                count1++;
            }
        }
        watch1.Stop();
        GC.Collect(GC.MaxGeneration,GCCollectionMode.Forced);
        int count2 = 0;
        var watch2 = Stopwatch.StartNew();
        for (int i = 0; i < 5000; i++)
        {
            foreach (var row in MyListCollection)
            {
                count2++;
            }
        }
        watch1.Stop();
        Console.WriteLine("Yield: {0} ({1})", watch1.ElapsedMilliseconds, count1);
        Console.WriteLine("List: {0} ({1})", watch2.ElapsedMilliseconds, count2);
    }
