    class DisposableQueue<T>:Queue<T>,IDisposable where T:IDisposable
    {
        public new void Clear() {
            foreach(T type in this){
                type.Dispose();
            }
            base.Clear();
        }
        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
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
