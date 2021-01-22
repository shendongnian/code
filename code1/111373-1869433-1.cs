    public class ObservableCollection<TBase, TActual> : IList<TBase>, IBindingList, INotifyCollectionChanged
        where TBase : class
        where TActual : class, TBase
    {
        
        private readonly ObservableCollection<TActual> innerList;
    
        public ObservableCollection()
            : this((IEnumerable<TActual>)null) {}
        public ObservableCollection(IEnumerable<TBase> data)
            : this(data == null ? null : data.Cast<TActual>()) {}
        public ObservableCollection(IEnumerable<TActual> data)
        {
            innerList = data == null ? new ObservableCollection<TActual>()
                : new ObservableCollection<TActual>(data);
            innerList.CollectionChanged += new NotifyCollectionChangedEventHandler(innerList_CollectionChanged);
        }
    
        void innerList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ListChangedEventHandler handler = ListChanged;
            if(handler != null) {
                ListChangedEventArgs args = null;
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        args = new ListChangedEventArgs(ListChangedType.ItemAdded, e.NewStartingIndex);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        args = new ListChangedEventArgs(ListChangedType.ItemDeleted, e.OldStartingIndex);
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        args = new ListChangedEventArgs(ListChangedType.Reset, -1);
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        args = new ListChangedEventArgs(ListChangedType.ItemChanged, e.NewStartingIndex);
                        break;
                    case NotifyCollectionChangedAction.Move:
                        args = new ListChangedEventArgs(ListChangedType.ItemMoved, e.NewStartingIndex, e.OldStartingIndex);
                        break;
                }
                if(args != null) handler(this, args);
            }
            NotifyCollectionChangedEventHandler handler2 = CollectionChanged;
            if (handler2 != null) handler2(this, e);
        }
    
        public void AddIndex(PropertyDescriptor property) {}
    
        public object AddNew()
        {
            TActual obj = (TActual)Activator.CreateInstance(typeof(TActual));
            Add(obj);
            return obj;
        }
    
        public bool AllowEdit { get { return !IsReadOnly; } }
        public bool AllowNew { get { return !IsFixedSize; } }
        public bool AllowRemove { get { return !IsFixedSize; } }
    
        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new System.NotImplementedException();
        }
    
        public int Find(PropertyDescriptor property, object key)
        {
            throw new System.NotImplementedException();
        }
    
        public bool IsSorted { get { return false; } }
    
        public event ListChangedEventHandler ListChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    
        public void RemoveIndex(PropertyDescriptor property) { }
    
        public void RemoveSort()
        {
            throw new System.NotImplementedException();
        }
    
        public ListSortDirection SortDirection
        {
            get { return ListSortDirection.Ascending; }
        }
    
        public PropertyDescriptor SortProperty
        {
            get { throw new System.NotImplementedException(); }
        }
    
        public bool SupportsChangeNotification { get { return true; } }
        public bool SupportsSearching { get { return false; } }
        public bool SupportsSorting { get { return false; } }
    
        int IList.Add(object value)
        {
            int index = innerList.Count;
            Add((TBase)value);
            return index;
        }
        public void Add(TBase value)
        {
            innerList.Add((TActual)value);
        }
    
        public void Clear()
        {
            innerList.Clear();
        }
    
        bool IList.Contains(object value)
        {
            return Contains((TBase)value);
        }
        public bool Contains(TBase value)
        {
            return innerList.Contains((TActual)value);
        }
    
        int IList.IndexOf(object value)
        {
            return IndexOf((TBase)value);
        }
        public int IndexOf(TBase value)
        {
            return innerList.IndexOf((TActual)value);
        }
    
        void IList.Insert(int index, object value)
        {
            Insert(index, (TBase)value);
        }
        public void Insert(int index, TBase value)
        {
            innerList.Insert(index, (TActual)value);
        }
    
        public bool IsFixedSize
        {
            get { return ((IList)innerList).IsFixedSize; }
        }
    
        public bool IsReadOnly
        {
            get { return ((IList)innerList).IsReadOnly; }
        }
    
        void IList.Remove(object value)
        {
            Remove((TBase)value);
        }
        public bool Remove(TBase value)
        {
            return innerList.Remove((TActual)value);
        }
    
        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }
    
        object IList.this[int index]
        {
            get { return innerList[index]; }
            set { innerList[index] = (TActual)value; }
        }
        public TBase this[int index]
        {
            get { return innerList[index]; }
            set { innerList[index] = (TActual)value; }
        }
    
        void ICollection.CopyTo(System.Array array, int index)
        {
            ((IList)innerList).CopyTo(array, index);
        }
        public void CopyTo(TBase[] array, int index)
        {
            innerList.CopyTo((TActual[])array, index);
        }
    
        public int Count { get { return innerList.Count; } }
    
        public bool IsSynchronized
        {
            get { return ((IList)innerList).IsSynchronized; }
        }
    
        public object SyncRoot
        {
            get { return ((IList)innerList).SyncRoot; }
        }
    
        public IEnumerator<TBase> GetEnumerator()
        {
            return innerList.Cast<TBase>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
