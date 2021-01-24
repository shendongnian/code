    public sealed class SimpleDisposable : IDisposable
    {
        public SimpleDisposable()
        {
            // acquire resources
        }
        ~SimpleDisposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            // Suppress calling the finalizer because resources will have been released by then.
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // release managed resources
                // (you don't want to do this when calling from the finalizer because the GC may have already finalized and collected them)
            }
            // release unmanaged resources
        }
    }
