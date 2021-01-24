    private object myLock = new object;
    private void foo()
    {
        if (Monitor.TryEnter(lockObject))
        {
            try
            {
                //do something
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
    }
