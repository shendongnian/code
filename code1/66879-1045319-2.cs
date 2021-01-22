    public class Cache2<T>: IEnumerable<T>
    {
        // changes occur to this list, and it is copied to ModifyableList
        private LinkedList<T> ModifyableList = new LinkedList<T>();
        // This list is the one that is iterated by GetEnumerator
        private volatile LinkedList<T> EnumeratedList = new LinkedList<T>();
        private readonly object LockObj = new object();
        public void Add(T item)
        {
            // on an add, we swap out the list that is being enumerated
            lock (LockObj)
            {
                if (this.ModifyableList.Count == 10)
                    this.ModifyableList.RemoveLast();
                this.ModifyableList.AddFirst(item);
                this.EnumeratedList = this.ModifyableList;
                // the copy needs to happen within the lock, so that threaded calls to Add() remain consistent
                this.ModifyableList = new LinkedList<T>(this.ModifyableList);
            }
                
        }
        #region IEnumerable<T> Members
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            IEnumerable<T> enumerable = this.EnumeratedList;
            return enumerable.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            System.Collections.IEnumerable enumerable = this.EnumeratedList;
            return enumerable.GetEnumerator();
        }
        #endregion
    }
