    public class BindableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IBindingList
    {
        private Dictionary<TKey, TValue> source = new Dictionary<TKey, TValue>();
        void IBindingList.AddIndex(PropertyDescriptor property) { }
        object IBindingList.AddNew() { throw new NotImplementedException(); }
        bool IBindingList.AllowEdit { get { return false; } }
        bool IBindingList.AllowNew { get { return false; } }
        bool IBindingList.AllowRemove { get { return false; } }
        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction) { }
        int IBindingList.Find(PropertyDescriptor property, object key) { throw new NotImplementedException(); }
        bool IBindingList.IsSorted { get { return false; } }
        void IBindingList.RemoveIndex(PropertyDescriptor property) { }
        void IBindingList.RemoveSort() { }
        ListSortDirection IBindingList.SortDirection { get { return ListSortDirection.Ascending; } }
        PropertyDescriptor IBindingList.SortProperty { get { return null; } }
        bool IBindingList.SupportsChangeNotification { get { return true; } }
        bool IBindingList.SupportsSearching { get { return false; } }
        bool IBindingList.SupportsSorting { get { return false; } }
        int System.Collections.IList.Add(object value) { throw new NotImplementedException(); }
        void System.Collections.IList.Clear() { Clear(); }
        bool System.Collections.IList.Contains(object value) { if (value is TKey) { return source.ContainsKey((TKey)value); } else if (value is TValue) { return source.ContainsValue((TValue)value); } return false; }
        int System.Collections.IList.IndexOf(object value) { return -1; }
        void System.Collections.IList.Insert(int index, object value) { throw new NotImplementedException(); }
        bool System.Collections.IList.IsFixedSize { get { return false; } }
        bool System.Collections.IList.IsReadOnly { get { return true; } }
        void System.Collections.IList.Remove(object value) { if (value is TKey) { Remove((TKey)value); } }
        void System.Collections.IList.RemoveAt(int index) { throw new NotImplementedException(); }
        object System.Collections.IList.this[int index] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        private ListChangedEventHandler listChanged;
        event ListChangedEventHandler IBindingList.ListChanged
        {
            add { listChanged += value; }
            remove { listChanged -= value; }
        }
        protected virtual void OnListChanged(ListChangedEventArgs e)
        {
            var evt = listChanged;
            if (evt != null) evt(this, e);
        }
        public void Add(TKey key, TValue value)
        {
            source.Add(key, value);
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        public bool Remove(TKey key)
        {
            if (source.Remove(key))
            {
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                return true;
            }
            return false;
        }
        public TValue this[TKey key]
        {
            get
            {
                return source[key];
            }
            set
            {
                source[key] = value;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)source).Add(item);
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            if (((ICollection<KeyValuePair<TKey, TValue>>)source).Remove(item))
            {
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                return true;
            }
            return false;
        }
        public bool ContainsKey(TKey key) { return source.ContainsKey(key); }
        public ICollection<TKey> Keys { get { return source.Keys; } }
        public bool TryGetValue(TKey key, out TValue value) { return source.TryGetValue(key, out value); }
        public ICollection<TValue> Values { get { return source.Values; } }
        public void Clear() { source.Clear(); }
        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item) { return ((ICollection<KeyValuePair<TKey, TValue>>)source).Contains(item); }
        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { ((ICollection<KeyValuePair<TKey, TValue>>)source).CopyTo(array, arrayIndex); }
        public int Count { get { return source.Count; } }
        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly { get { return ((ICollection<KeyValuePair<TKey, TValue>>)source).IsReadOnly; } }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() { return source.GetEnumerator(); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
