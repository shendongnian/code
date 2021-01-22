    public class Cache3<T> : IEnumerable<T>
    {
        private LinkedList<T> InternalCache = new LinkedList<T>();
        private readonly System.Threading.ReaderWriterLockSlim LockObj = new System.Threading.ReaderWriterLockSlim();
        public void Add(T item)
        {
            this.LockObj.EnterWriteLock();
            try
            {
                if(this.InternalCache.Count == 10)
                    this.InternalCache.RemoveLast();
                this.InternalCache.AddFirst(item);
            }
            finally
            {
                this.LockObj.ExitWriteLock();
            }
        }
        #region IEnumerable<T> Members
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            this.LockObj.EnterReadLock();
            try
            {
                foreach(T item in this.InternalCache)
                    yield return item;
            }
            finally
            {
                this.LockObj.ExitReadLock();
            }
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            this.LockObj.EnterReadLock();
            try
            {
                foreach (T item in this.InternalCache)
                    yield return item;
            }
            finally
            {
                this.LockObj.ExitReadLock();
            }
        }
        #endregion
    }
