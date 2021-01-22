    class StackOTest
    {
        private delegate DateTime ReadLockMethod();
        private delegate void WriteLockMethod();
    
        static ReaderWriterLock rwlMyLock_m  = new ReaderWriterLock();
        private DateTime dtMyDateTime_m;
        public DateTime MyDateTime
        {
            get
            {
                return ReadLockedMethod(
                    delegate () { return dtMyDateTime_m; }
                );
            }
            set
            {
                WriteLockedMethod(
                    delegate () { dtMyDateTime_m = value; }
                );
            }
        }
    
        private DateTime ReadLockedMethod(ReadLockMethod method)
        {
            rwlMyLock_m.AcquireReaderLock(0);
            try
            {
                return method();
            }
            finally
            {
                rwlMyLock_m.ReleaseReaderLock();
            }
        }
    
        private void WriteLockedMethod(WriteLockMethod method)
        {
            rwlMyLock_m.AcquireWriterLock(0);
            try
            {
                method();
            }
            finally
            {
                rwlMyLock_m.ReleaseWriterLock();
            }
        }
    }
