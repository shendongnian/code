    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class ListSet<T> : IList<T>, ISet<T> // ISet<T> is supported only from .NET 4.0 on
    {
        #region Inner collections
        private HashSet<T> _innerSet = new HashSet<T>();
        private List<T> _innerList = new List<T>();
        #endregion
        #region The read methods delegate to the inner collection which is more appropriate and efficient:
        public bool Contains(T item)
        {
            return this._innerSet.Contains(item);
        }
        public int IndexOf(T item)
        {
            return this._innerList.IndexOf(item);
        }
        // TODO: Implement all other read operations
        #endregion
        #region The write methods must keep both inner collections synchronized
        public bool Add(T item)
        {
            bool wasAdded = this._innerSet.Add(item);
            if (wasAdded) this._innerList.Add(item);
            return wasAdded;
        }
        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items) this.Add(item);
        }
        public bool Remove(T item)
        {
            if (this._innerSet.Remove(item))
            {
                return this._innerList.Remove(item);
            }
            return false;
        }
        // TODO: Implement all other write operations
        // TODO: Consider implementing roll back mechanisms in exception handlers
        //            when write operations fail
        #endregion
    }
    
