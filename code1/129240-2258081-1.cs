        public IEnumerator<T> GetEnumerator()
        {
            List<T> localList;
            _lock.EnterReadLock();
            try { localList= new List<T>(_actualList); }
            finally { _lock.ExitReadLock(); }
            foreach (T item in localList) yield return item;
        }
