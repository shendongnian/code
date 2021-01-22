    public interface ILock
    {
    }
    public class MyLockable
    {
        private MyLock _lock;
        public void AddOne()
        {
            if (_lock == null)
                throw new InvalidOperationException("Lockable must be locked " +
                    "before running this method.");
            if (Monitor.TryEnter(_lock.Sync))
            {
                try
                {
                    // Do the work here
                }
                finally
                {
                    Monitor.Exit(_lock.Sync);
                }
            }
            else
            {
                throw new InvalidOperationException("Thread used to call AddOne " +
                    "is not the same thread used to lock.");
            }
        }
        public ILock Lock()
        {
            if (_lock != null)
                throw new InvalidOperationException("Already locked.");
            _lock = new MyLock(this);
            Monitor.Enter(_lock.Sync);
            return _lock;
        }
        public void Unlock(ILock _lock)
        {
            if (_lock != this._lock)
                throw new ArgumentException("Invalid lock used to unlock", "_lock");
            Monitor.Exit(_lock.Sync);
            this._lock = null;
        }
        class MyLock : ILock
        {
            public object Sync = new Object();
        }
    }
