    class StackOTest
    {
        static ReaderWriterLock rwlMyLock_m  = new ReaderWriterLock();
        private DateTime dtMyDateTime_m;
        public DateTime MyDateTime
        {
            get
            {
                DateTime retval = default(DateTime);
                ReadLockedMethod(
                    delegate () { retval = dtMyDateTime_m; }
                );
                return retval;
            }
            set
            {
                WriteLockedMethod(
                    delegate () { dtMyDateTime_m = value; }
                );
            }
        }
    
        private void ReadLockedMethod(Action method)
        {
            rwlMyLock_m.AcquireReaderLock(0);
            try
            {
                method();
            }
            finally
            {
                rwlMyLock_m.ReleaseReaderLock();
            }
        }
    
        private void WriteLockedMethod(Action method)
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
