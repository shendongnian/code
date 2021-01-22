    public abstract class WorkObject : IDispose
    {
        ManualResetEvent _waitHandle = new ManualResetEvent(false);
        
        public void DoSomeWork()
        {
            try
            {
                this.DoSomeWorkOverride();
            }
            finally
            {
                _waitHandle.Set();
            }
        }
    
        protected abstract DoSomeWorkOverride();
    
        public void WaitForCompletion()
        {
            _waitHandle.WaitOne();
        }
    
        public void Dispose()
        {
            _waitHandle.Dispose();
        }
    }
