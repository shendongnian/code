    public class ValueEventArgs : EventArgs
    {
        public int Value { get;set;}
    }
    public class ExceptionEventArgs : EventArgs
    {
        public Exception Exception { get;set;}
    }
    public class LongRunningTask
    {
        private bool canceled = false;
    
        public event EventHandler<ValueEventArgs> Completed = delegate {}
        public event EventHandler<ExceptionEventArgs> GotError = delegate {}
    
        public void Cancel()
        {
            canceled = true;
        }
    
        public void FetchInt()
        {
            try
            {
                int result = 0;
                for (int i = 0; i < 1000; i++)
                {
                    if (canceled)
                        return;
                    result++; 
                }
                Completed(this, new ValueEventArgs {Value = result});
            }
            catch(Exception exc)
            {
                GotError(this, new ExceptionEventArgs { Exception = exc });
            }
        }
    
        public void BeginFetchInt()
        {
            ThreadPool.QueueUserWorkItem(i => FetchInt());
        }
    }
