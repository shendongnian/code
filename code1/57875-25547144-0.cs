    public abstract class DisposableObject : IDisposable
    {
        public bool Disposed { get; private set;}      
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        ~DisposableObject()
        {
            Dispose(false);
        }
    
        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DisposeManagedResources();
                }
    
                DisposeUnmanagedResources();
                Disposed = true;
            }
        }
    
        protected virtual void DisposeManagedResources() { }
        protected virtual void DisposeUnmanagedResources() { }
    }
