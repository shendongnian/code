    public abstract class BaseCriticalResource : IDiposable {
        ~ BaseCriticalResource () {
            Dispose(false);
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this); // No need to call finalizer now
        }
        protected virtual void Dispose(bool disposing) { }
    }
