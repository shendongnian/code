    internal class CanBeDisposed : IDisposable
    {
        private bool disposed;
        public bool Disposed
        {
            get
            {
                if (!this.disposed)
                    return this.disposed;
                throw new ObjectDisposedException("CanBeDisposed");
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //// Dispose of managed resources.
                }
                //// Dispose of unmanaged resources.
                this.disposed = true;
            }
        }
    }
