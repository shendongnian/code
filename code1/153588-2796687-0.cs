    public class ObjectHolder<T>
    {
        private T value;
        private ManualResetEvent waitEvent = new ManualResetEvent(false);
    
        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
    
                ManualResetEvent evt = waitEvent;
    
                if(evt != null)
                {
                    evt.Set();
                    evt.Dispose();
                    evt = null;
                }
            }
        }
    
        public bool IsValueSet
        {
            get { return waitEvent == null; }
        }
    
        public void WaitUntilHasValue()
        {
            ManualResetEvent evt = waitEvent;
    
            if(evt != null) evt.WaitOne();
        }
    }
