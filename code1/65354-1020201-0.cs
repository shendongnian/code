    class SomeData
    {
        private IList<string> _someStrings = new List<string>();
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    
        public void Add(string text)
        {
            _lock.EnterWriteLock();            
            try
            {
                _someStrings.Add(text);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
    
        }
    
        public bool Contains(string text)
        {
            _lock.EnterReadLock();
            try
            {
                return _someStrings.Contains(text);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    }
