    class ReadLockHelper : IDisposable
    {
      public ReadLockHelper(ReaderWriterLockSlim rwLock)
      {
        rwLock.AcquireReadLock(-1);
        this.rwLock = rwLock;
      }
      public void Dispose()
      {
        rwLock.ReleaseReadLock();
      }
      private ReaderWriterLockSlim rwLock;
    }
