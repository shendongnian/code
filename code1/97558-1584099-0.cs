    public void StartTheActions()
    {
        ManualResetEvent syncEvent = new ManualResetEvent(false);
    
        Thread t1 = new Thread(
            () =>
            {
                // Do some work...
                syncEvent.Set();
            }
        );
        t1.Start();
    
        Thread t2 = new Thread(
            () =>
            {
                syncEvent.WaitOne();
    
                // Do some work...
            }
        );
        t2.Start();
    }
