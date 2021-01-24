    try
    {
        if (isSpecialCase || Monitor.TryEnter(myLock, TimeSpan.MaxValue))
        {
            // critical code01
        }
    }
    finally
    {
        if (!isSpecialCase)
        {
            // lock was taken
            Monitor.Exit(myLock);
        }
    }
