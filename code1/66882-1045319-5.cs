    public class Cache2&lt;T>: IEnumerable&lt;T>
    {
        // changes occur to this list, and it is copied to ModifyableList
        private LinkedList&lt;T> ModifyableList = new LinkedList&lt;T>();
        // This list is the one that is iterated by GetEnumerator
        private volatile LinkedList&lt;T> EnumeratedList = new LinkedList&lt;T>();
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
                this.ModifyableList = new LinkedList&lt;T>(this.ModifyableList);
            }
                
        }
        #region IEnumerable&lt;T> Members
        IEnumerator&lt;T> IEnumerable&lt;T>.GetEnumerator()
        {
            IEnumerable&lt;T> enumerable = this.EnumeratedList;
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
