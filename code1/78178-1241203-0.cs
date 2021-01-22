    class DictionaryHolder
    {
        private IDictionary<int, string> _data = new Dictionary<int, string>();
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        public void Update(int key, string value)
        {
            _lock.EnterWriteLock();            
            try
            {
                _data[key] = value;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    
        public string GetValue(int key)
        {
            _lock.EnterReadLock();
            try
            {
                if (_data.ContainsKey(key))
                {
                    return _data[key];
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    }
