    public class ClassThatHoldsUnmanagedResource : IDisposable
    {
        private IntPtr _HandleToSomethingUnmanaged;
        public ClassThatHoldsUnmanagedResource()
        {
            _HandleToSomethingUnmanaged = (... open file, whatever);
        }
        ~ClassThatHoldsUnmanagedResource()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            (release unmanaged resource here);
            ... rest of dispose
        }
        public void Test()
        {
            IntPtr local = _HandleToSomethingUnmanaged;
            // DANGER!
            ... access resource through local here
        }
