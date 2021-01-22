    internal class IdLock
    {
        internal int LockDictionarySize
        {
            get { return m_lockDictionarySize; }
        }
        const int m_lockDictionarySize = 1000;
        ConcurrentDictionary<int, object> m_locks = new ConcurrentDictionary<int, object>();
        internal object this[ int id ]
        {
            get
            {
                object lockObject = new object();
                int mapValue = id % m_lockDictionarySize;
                lockObject = m_locks.GetOrAdd( mapValue, lockObject );
                return lockObject;
            }
        }
    }
