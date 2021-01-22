    // Base class
        #region IDisposable Members
        private bool _isDisposed;
        public void Dispose()
        {
            this.Dispose(true);
            // GC.SuppressFinalize(this); // Call after Dispose; only use if there is a finalizer.
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    // Clear down managed resources.
                    
                    if (this.Database != null)
                        this.Database.Dispose();
                }
                _isDisposed = true;
            }
        }
        #endregion
    // Subclass
        #region IDisposable Members
        private bool _isDisposed;
        protected override void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    // Clear down managed resources.
                    if (this.Resource != null)
                        this.Resource.Dispose();
                }
                _isDisposed = true;
            }
            base.Dispose(isDisposing);
        }
        #endregion
