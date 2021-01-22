        public class List<T> : IList<T>, ICollection<T>, IEnumerable<T>, IList, ICollection, IEnumerable
        {
            public List();
            public List(int capacity);
            public List(IEnumerable<T> collection);
            public int Capacity { get; set; }
    
            #region IList Members
    
            int IList.Add(object item);
            bool IList.Contains(object item);
            void ICollection.CopyTo(Array array, int arrayIndex);
            int IList.IndexOf(object item);
            void IList.Insert(int index, object item);
            void IList.Remove(object item);
            bool IList.IsFixedSize { get; }
            bool IList.IsReadOnly { get; }
            bool ICollection.IsSynchronized { get; }
            object ICollection.SyncRoot { get; }
            object IList.this[int index] { get; set; }
    
            #endregion
    
    ...and so on
    
    }
