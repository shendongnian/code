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
                    rwlMyLock_m,
                    delegate () { return dtMyDateTime_m; }
                );
            }
            set
            {
                WriteLockedMethod(
                    rwlMyLock_m,
                    delegate () { dtMyDateTime_m = value; }
                );
            }
        }
    
        private static DateTime ReadLockedMethod(
            ReaderWriterLock rwl,
            ReadLockMethod method
        )
        {
            rwl.AcquireReaderLock(0);
            try
            {
                return method();
            }
            finally
            {
                rwl.ReleaseReaderLock();
            }
        }
    
        private static void WriteLockedMethod(
            ReaderWriterLock rwl,
            WriteLockMethod method
        )
        {
            rwl.AcquireWriterLock(0);
            try
            {
                method();
            }
            finally
            {
                rwl.ReleaseWriterLock();
            }
        }
    }
