    public void Lock_Performance_Test()
    {
        Stopwatch csLock = Stopwatch.StartNew();
        int i = 0;
        while (i < 100)
        {
            object CS$2$0000;
            bool <>s__LockTaken0 = false;
            try
            {
                Monitor.Enter(CS$2$0000 = this.object1, ref <>s__LockTaken0);
                i++;
            }
            finally
            {
                if (<>s__LockTaken0)
                {
                    Monitor.Exit(CS$2$0000);
                }
            }
        }
        csLock.Stop();
        Stopwatch csMonitor = Stopwatch.StartNew();
        i = 0;
        while (i < 100)
        {
            if (Monitor.TryEnter(this.object1, TimeSpan.FromSeconds(10.0)))
            {
                try
                {
                    i++;
                }
                finally
                {
                    Monitor.Exit(this.object1);
                }
            }
        }
        csMonitor.Stop();
        Console.WriteLine("Lock: {0:f1} microseconds", csLock.Elapsed.Ticks / 10M);
        Console.WriteLine("Monitor.TryEnter: {0:f1} microseconds", csMonitor.Elapsed.Ticks / 10M);
    }
    
     
 
