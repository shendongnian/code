    public class BusyLock : IDisposable
    {
        private readonly Object _lockObject = new Object();
        private int _lockCount;
        public bool IsBusy
        {
            get { return _lockCount > 0; }
        }
        public IDisposable Enter()
        {
            if (!Monitor.TryEnter(_lockObject, TimeSpan.FromSeconds(1.0)))
                throw new InvalidOperationException("Cannot begin operation as system is already busy");
            Interlocked.Increment(ref _lockCount);
            return this;
        }
        public bool TryEnter(out IDisposable busyLock)
        {
            if (Monitor.TryEnter(_lockObject))
            {
                busyLock = this;
                Interlocked.Increment(ref _lockCount);
                return true;
            }
            busyLock = null;
            return false;
        }
        #region IDisposable Members
        public void Dispose()
        {
            if (_lockCount > 0)
            {
                Monitor.Exit(_lockObject);
                Interlocked.Decrement(ref _lockCount);
            }
        }
        #endregion
    }
