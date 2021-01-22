    Timer UpdateTimer = new Timer(UpdateCallback, null, 30000, 30000);
    
    object updateLock = new object();
    void UpdateCallback(object state)
    {
        if (Monitor.TryEnter(updateLock))
        {
            try
            {
                // do stuff here
            }
            finally
            {
                Monitor.Exit(updateLock);
            }
        }
        else
        {
            // previous timer tick took too long.
            // so do nothing this time through.
        }
    }
