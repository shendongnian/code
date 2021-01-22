    static object mylock = new object();
....
    if (Monitor.TryEnter(mylock, 0))
    {
        try
        {
               // Do work
        }
        finally
        {
            Monitor.Exit(mylock);
        }
    }
