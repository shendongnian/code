    internal static class ReaderWriteLockExtensions
    {
        private struct Disposable : IDisposable
        {
            private readonly Action m_action;
            private Sentinel m_sentinel;
            public Disposable(Action action)
            {
                m_action = action;
                m_sentinel = new Sentinel();
            }
            public void Dispose()
            {
                m_action();
                GC.SuppressFinalize(m_sentinel);
            }
        }
        private class Sentinel
        {
            ~Sentinel()
            {
                throw new InvalidOperationException("Lock not properly disposed.");
            }
        }
       
        public static IDisposable AcquireReadLock(this ReaderWriterLockSlim lock)
        {
            lock.EnterReadLock();
            return new Disposable(lock.ExitReadLock);
        }
        public static IDisposable AcquireUpgradableReadLock(this ReaderWriterLockSlim lock)
        {
            lock.EnterUpgradeableReadLock();
            return new Disposable(lock.ExitUpgradeableReadLock);
        }
        public static IDisposable AcquireWriteLock(this ReaderWriterLockSlim lock)
        {
            lock.EnterWriteLock();
            return new Disposable(lock.ExitWriteLock);
        }
    } 
