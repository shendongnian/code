    // Make this a static field
    ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    _lock.EnterWriteLock();
    try
    {
        File.WriteAllText(@"c:\test.txt", "some info to write");
    }
    finally
    {
        _lock.ExitWriteLock();
    }
