    class DisposableQueue<T>:Queue<T>,IDisposable where T:IDisposable
        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing) {
            if (disposing) {
                foreach (T type in this) {
                    try
                    {
                        type.Dispose();
                    }
                    finally {/* In case of ObjectDisposedException*/}
                }
            }
        }
        #endregion
    }
