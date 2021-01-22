    public class Cache3&lt;T> : IEnumerable&lt;T>
    {
        private LinkedList&lt;T> InternalCache = new LinkedList&lt;T>();
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
        #region IEnumerable&lt;T> Members
        IEnumerator&lt;T> IEnumerable&lt;T>.GetEnumerator()
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
