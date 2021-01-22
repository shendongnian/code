        public void Dispose()
        {
            this.Dispose(true);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }
            }
            //Dispose of resources here
            this.isDisposed = true;
        }
    
        ~DisposableSafe()
        {
            this.Dispose(false);
        }
    
        private bool isDisposed = false;
