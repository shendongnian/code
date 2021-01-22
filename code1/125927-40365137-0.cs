    internal class ThreadSafeIndexerClass
    {
        public object this[int key]
        {
            get
            {
				// Aquire returns IDisposable and does Enter() Exit() on a certain ReaderWriterLockSlim instance
                using (_readLock.Aquire()) 
                {
                    object subset;
                    _dictionary.TryGetValue(key, out foundValue);
                    return foundValue;
                }
            }
            set
            {
				// Aquire returns IDisposable and does Enter() Exit() on a certain ReaderWriterLockSlim instance
                using (_writeLock.Aquire())
                    _dictionary[key] = value;
            }
        }
    }
