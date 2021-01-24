            var _storageLocker = new ReaderWriterLockSlim();
            using (var lockContext =new ReadLockContext(_storageLocker))
            {
                if (lockContext.IsAcquired)
                {
                }
            }
    public struct ReadLockContext : IDisposable
    {
        private readonly ReaderWriterLockSlim locker;
        public ReadLockContext(ReaderWriterLockSlim locker, TimeSpan timeout = default(TimeSpan))
        {
            if (timeout == default(TimeSpan))
                timeout = TimeSpan.FromMilliseconds(-1);
            if (locker.TryEnterReadLock(timeout))
                this.locker = locker;
            else
                this.locker = null;
        }
        public bool IsAcquired => locker != null;
        public void Dispose()
        {
            locker?.ExitReadLock();
        }
    }
