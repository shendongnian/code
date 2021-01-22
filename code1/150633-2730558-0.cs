    public class ResourceReleaser<T> : IDisposable
    {
        private Action<T> _action;
        private bool _disposed;
        private T _val;
        public ResourceReleaser(T val, Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            _action = action;
            _val = val;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~ResourceReleaser()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                _disposed = true;
                _action(_val);
            }
        }
    }
