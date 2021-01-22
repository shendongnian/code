    if (Monitor.TryEnter(locker)
    {
        try
        {
            // Do your work here.
        }
        finally
        {
            Monitor.Exit(locker);
        }
    }
