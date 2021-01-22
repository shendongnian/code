    public class AutoMutex : IDisposable
    {
        private Mutex _mutex;  
        public AutoMutex(Mutex mutex)
        {
           _mutex = mutex;
           _mutex.WaitOne();
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
     
        void Dispose(bool disposing)
        {
            // method may be called more than once from different threads
            // you should avoid exceptions in the Dispose method
            var victim = _mutex;
            _mutex = null;
            if(victim != null)
            {
              victim.ReleaseMutex();
              victim.Dispose();
            }
            if(disposing)
            {
              // release managed resources here
            }
        }
    }
