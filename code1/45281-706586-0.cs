    public class Connection : IDisposable
    {
        #region Dispose pattern
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
                ReleaseManagedResources();
        }
        /// <summary>
        /// Derived classes from this class should override this method
        /// to clean up managed resources when Dispose is called.
        /// </summary>
        protected virtual void ReleaseManagedResources()
        {
            // Enter managed resource cleanup code here.
        }
        /// <summary>
        /// Derived classes should override this method to clean up
        /// unmanaged resources when Dispose is called.
        /// </summary>
        protected virtual void ReleaseUnmanagedResources()
        {
            // Enter unmanaged resource cleanup code here.
        }
        #endregion
