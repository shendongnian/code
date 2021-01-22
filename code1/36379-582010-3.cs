    public abstract class PFServer2ServerClientBase<TChannel> : ClientBase<TChannel>, IDisposable where TChannel : class
    {
        private bool disposed = false;
        public PFServer2ServerClientBase()
        {
            // Copy information from custom identity into credentials, and other channel setup...
        }
        ~PFServer2ServerClientBase()
        {
            this.Dispose(false);
        }
        void IDisposable.Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                        if (this.State == CommunicationState.Opened)
                            this.Close();
                }
                finally
                {
                    if (this.State == CommunicationState.Faulted)
                        this.Abort();
                }
                this.disposed = true;
            }
        }
    }
