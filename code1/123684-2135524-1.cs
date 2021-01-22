    public class ThreadSafeClass
    {
        private readonly ReaderWriterLock theLock = new ReaderWriterLock();
    
        private double propertyA;
        public double PropertyA
        {
            get
            {
                theLock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    return propertyA;
                }
                finally
                {
                    theLock.ReleaseReaderLock();
                }
            }
            set
            {
                theLock.AcquireWriterLock(Timeout.Infinite);
                try
                {
                    propertyA = value;
                }
                finally
                {
                    theLock.ReleaseWriterLock();
                }
            }
        }
    
        private double propertyB;
        public double PropertyB
        {
            get
            {
                theLock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    return propertyB;
                }
                finally
                {
                    theLock.ReleaseReaderLock();
                }
            }
            set
            {
                theLock.AcquireWriterLock(Timeout.Infinite);
                try
                {
                    propertyB = value;
                }
                finally
                {
                    theLock.ReleaseWriterLock();
                }
            }
        }
    
        public void SomeMethod()
        {
            theLock.AcquireWriterLock(Timeout.Infinite);
            try
            {
                theLock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    PropertyA = 2.0 * PropertyB;
                }
                finally
                {
                    theLock.ReleaseReaderLock();
                }
            }
            finally
            {
                theLock.ReleaseWriterLock();
            }
        }
    }
