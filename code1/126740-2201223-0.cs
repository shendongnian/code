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
            // method may be called more than once
            // use locking to make this thread safe
            if(_mutex != null)
            {
              _mutex.ReleaseMutex();
              _mutex.Dispose();
            }
            _mutex = null;
            if(disposing)
            {
              // release managed resources here
            }
        }
    }
