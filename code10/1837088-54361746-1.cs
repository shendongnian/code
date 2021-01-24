    public abstract class BaseDisposable : IDisposable
    {
        protected BaseDisposable()
        {
            // acquire resources
        }
        ~BaseDisposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // release managed resources
            }
            // release unmanaged resoures
        }
    }
