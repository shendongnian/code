    void Main()
    {
        ParallelThread();
        ParallelProcess();
    }
    
    public static bool ParallelProcess()
    {
        Stopwatch sw = new Stopwatch();
    
        sw.Start();
        Parallel.For(0, 100, x =>
        {
            /*Console.WriteLine(string.Format("Printing {0} thread = {1}", x,
                Thread.CurrentThread.ManagedThreadId));*/
            Thread.Sleep(3000);
        });
        sw.Stop();
        Console.WriteLine(string.Format("Time in secs {0}", sw.Elapsed.Seconds));
    
        return true;
    }
    
    public static bool ParallelThread()
    {
        Stopwatch sw = new Stopwatch();
    
        sw.Start();
        var events = new ManualResetEvent[100];
            for (int i = 0; i < 100; i++)
        {
            int x = i;
            events[x] = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem
                (
                    _ =>
                    {
                        Thread1(x);
                        events[x].Set();
                    }
                );
        }
        for (int i = 0; i < 100; i++)
        {
            events[i].WaitOne();
        }
        sw.Stop();
        Console.WriteLine(string.Format("Time in secs {0}", sw.Elapsed.Seconds));
    
        return true;
    }
    
    private static void Thread1(int x)
    {
        /*Console.WriteLine(string.Format("Printing {0} thread = {1}", x,
               Thread.CurrentThread.ManagedThreadId));*/
        Thread.Sleep(3000);
    }
