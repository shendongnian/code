    public interface ILock : IDisposable
    {
    }
    public class ThreadGuard
    {
        private static readonly object SlotMarker = new Object();
        [ThreadStatic]
        private static Dictionary<Guid, object> locks;
        private Guid lockID;
        private object sync = new Object();
        public void BeginGuardedOperation()
        {
            lock (sync)
            {
                if (lockID == Guid.Empty)
                    throw new InvalidOperationException("Guarded operation " +
                        "was blocked because no lock has been obtained.");
                object currentLock;
                Locks.TryGetValue(lockID, out currentLock);
                if (currentLock != SlotMarker)
                {
                    throw new InvalidOperationException("Guarded operation " +
                        "was blocked because the lock was obtained on a " +
                        "different thread from the calling thread.");
                }
            }
        }
        public ILock GetLock()
        {
            lock (sync)
            {
                if (lockID != Guid.Empty)
                    throw new InvalidOperationException("This instance is " +
                        "already locked.");
                lockID = Guid.NewGuid();
                Locks.Add(lockID, SlotMarker);
                return new ThreadGuardLock(this);
            }
        }
        private void ReleaseLock()
        {
            lock (sync)
            {
                if (lockID == Guid.Empty)
                    throw new InvalidOperationException("This instance cannot " +
                        "be unlocked because no lock currently exists.");
                object currentLock;
                Locks.TryGetValue(lockID, out currentLock);
                if (currentLock == SlotMarker)
                {
                    Locks.Remove(lockID);
                    lockID = Guid.Empty;
                }
                else
                    throw new InvalidOperationException("Unlock must be invoked " +
                        "from same thread that invoked Lock.");
            }
        }
        public bool IsLocked
        {
            get
            {
                lock (sync)
                {
                    return (lockID != Guid.Empty);
                }
            }
        }
        protected static Dictionary<Guid, object> Locks
        {
            get
            {
                if (locks == null)
                    locks = new Dictionary<Guid, object>();
                return locks;
            }
        }
        #region Lock Implementation
        class ThreadGuardLock : ILock
        {
            private ThreadGuard guard;
            public ThreadGuardLock(ThreadGuard guard)
            {
                this.guard = guard;
            }
            public void Dispose()
            {
                guard.ReleaseLock();
            }
        }
        #endregion
    }
