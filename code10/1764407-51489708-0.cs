    public class MyWrapperList<T> : IList<T>, INotifyPropertyChanged, INotifyCollectionChanged, IList
    {
        //... all your existing code plus: (add your own implementation)
        #region IList 
        void ICollection.CopyTo(Array array, int index) => throw new NotImplementedException();        
        bool IList.IsFixedSize => throw new NotImplementedException();
        bool IList.Contains(object value) => throw new NotImplementedException();       
        int IList.IndexOf(object value) => throw new NotImplementedException();
        void IList.Insert(int index, object value) => throw new NotImplementedException();
        void IList.Remove(object value) => throw new NotImplementedException();
        int IList.Add(object value) => throw new NotImplementedException();
        public bool IsSynchronized => throw new NotImplementedException();
        public object SyncRoot { get; } = new object();
        object IList.this[int index] {
            get => this[index];
            set => this[index] = (T) value;
        }
        #endregion
    }
