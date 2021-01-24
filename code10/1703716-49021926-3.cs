    public static void Synchronize()
    {
        if (th1 == null || !th1.ThreadState.In(System.Threading.ThreadState.Running, System.Threading.ThreadState.WaitSleepJoin))
        {
            Debug.WriteLine("Starting new thread...");
            th1 = new Thread(new ThreadStart(thr_sync));
            th1.Start();
        }
        else
            Debug.WriteLine("Thread is already started. Waiting for the end...");
        if (th1.Join(10000))
            Debug.WriteLine("Done");
        else
            Debug.WriteLine("Time out");
    }
    static void thr_sync()
    {
        //Imitation of activity
        Thread.Sleep(3000);
    }
