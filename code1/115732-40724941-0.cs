    public class ThreadCounter
    {
        #region Variables
        private int currentCount, maxCount;
        private ManualResetEvent eqZeroEvent;
        private object instanceLock = new object();
        #endregion
        #region Properties
        public int CurrentCount
        {
            get
            {
                return currentCount;
            }
            set
            {
                lock (instanceLock)
                {
                    currentCount = value;
                    AdjustZeroEvent();
                    AdjustMaxEvent();
                }
            }
        }
        public int MaxCount
        {
            get
            {
                return maxCount;
            }
            set
            {
                lock (instanceLock)
                {
                    maxCount = value;
                    AdjustMaxEvent();
                }
            }
        }
        #endregion
        #region Constructors
        public ThreadCounter() : this(0) { }
        public ThreadCounter(int initialCount) : this(initialCount, int.MaxValue) { }
        public ThreadCounter(int initialCount, int maximumCount)
        {
            currentCount = initialCount;
            maxCount = maximumCount;
            eqZeroEvent = currentCount == 0 ? new ManualResetEvent(true) : new ManualResetEvent(false);
        }
        #endregion
        #region Public Methods
        public void Increment()
        {
            ++CurrentCount;
        }
        public void Decrement()
        {
            --CurrentCount;
        }
        public void WaitUntilZero()
        {
            eqZeroEvent.WaitOne();
        }
        #endregion
        #region Private Methods
        private void AdjustZeroEvent()
        {
            if (currentCount == 0) eqZeroEvent.Set();
            else eqZeroEvent.Reset();
        }
        private void AdjustMaxEvent()
        {
            if (currentCount <= maxCount) Monitor.Pulse(instanceLock);
            else do { Monitor.Wait(instanceLock); } while (currentCount > maxCount);
        }
        #endregion
    }
