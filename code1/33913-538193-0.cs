    public class SimpleCleanup : IDisposable
    {
        // some fields that require cleanup
        private SafeHandle handle;
        private bool disposed = false; // to detect redundant calls
    
        public SimpleCleanup()
        {
            this.handle = /*...*/;
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    if (handle != null)
                    {
                        handle.Dispose();
                    }
                }
    
                // Dispose unmanaged managed resources.
                disposed = true;
            }
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
