    ReadWriterLockSlim lck = new ReadWriterLockSlim();
    
    ...
    
    lck.EnterReadLock();
    try
    {
        ...
    }
    finally
    {
        lck.ExitReadLock();
    }
