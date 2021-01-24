    public static class ReaderWriterLockSlimExtensions
    {
        public static void ExecuteWrite(this ReaderWriterLockSlim aLock, Action action)
        {
            aLock.EnterWriteLock();
            try
            {
                action();
            }
            finally
            {
                aLock.ExitWriteLock();
            }
        }
        public static void ExecuteRead(this ReaderWriterLockSlim aLock, Action action)
        {
            aLock.EnterReadLock();
            try
            {
                action();
            }
            finally
            {
                aLock.ExitReadLock();
            }
        }
    }
