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
