    public static IDisposable GetReadLock(this ReaderWriterLockSlim slimLock)
    {
      slimLock.EnterReadLock();
      return new DisposableAction(slimLock.ExitReadLock);
    }
    
    public static IDisposable GetWriteLock(this ReaderWriterLockSlim slimLock)
    {
      slimLock.EnterWriteLock();
      return new DisposableAction(slimLock.ExitWriteLock);
    }
    
    public static IDisposable GetUpgradeableReadLock(this ReaderWriterLockSlim slimLock)
    {
      slimLock.EnterUpgradeableReadLock();
      return new DisposableAction(slimLock.ExitUpgradeableReadLock);
    }
