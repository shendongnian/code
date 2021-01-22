    using (var poolGuard = new PoolGuard())
    {
        for (int i = 0; i < ...
        {
            ThreadPool.QueueUserWorkItem(ChildThread, poolGuard);
        }
        // Do stuff.
        poolGuard.WaitOne();
        // Do stuff that required the child threads to have ended.
    void ChildThread(object state)
    {
        var poolGuard = state as PoolGuard;
        if (poolGuard.TryEnter())
        {
            try
            {
                // Do stuff.
            }
            finally
            {
                poolGuard.Exit();
            }
        }
    }
