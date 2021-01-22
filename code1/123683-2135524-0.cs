    public class ThreadSafeClass
    {
        private readonly object readLockA = new object();
        private readonly object readLockB = new object();
        private readonly object writeLock= new object();
    
        private double propertyA;
        public double PropertyA
        {
            get
            {
                lock (readLockA)
                {
                    return propertyA;
                }
            }
            set
            {
                lock (readLockA)
                lock (writeLock)
                {
                    propertyA = value;
                }
            }
        }
    
        private double propertyB;
        public double PropertyB
        {
            get
            {
                lock (readLockB)
                {
                    return propertyB;
                }
            }
            set
            {
                lock (readLockB)
                lock (writeLock)
                {
                    propertyB = value;
                }
            }
        }
    
        public void SomeMethod()
        {
            lock (readLockB)
            lock (writeLock)
            {
                PropertyA = 2.0 * PropertyB;
            }
        }
    }
