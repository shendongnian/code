    public class SomeService
    {
        private readonly object lockObject = new object();
    
        public void StartSomeMethod()
        {
            if (Monitor.TryEnter(lockObject))
            {
                // start new thread
            }
        }
    
        public void SomeMethod()
        {
            try
            {
                // ...
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }    
    }
