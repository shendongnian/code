    private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    _lock.EnterWriteLock();
    try
    {
        // safe mutation
        DoggieList.Add(...
    }
    finally
    {
        _lock.ExitWriteLock();
    }
