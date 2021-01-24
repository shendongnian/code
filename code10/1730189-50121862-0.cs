    public class LimitedSizeObservableCollection<T> : INotifyCollectionChanged
    {        
        private ObservableCollection<T> _collection;
        private bool _ignoreChange;
        
        public LimitedSizeObservableCollection(int capacity)
        {
            Capacity = capacity;
            _ignoreChange = false;
            _collection = new ObservableCollection<T>();
            _collection.CollectionChanged += _collection_CollectionChanged;
        }
        
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        
        public int Capacity {get;}
        
        public void Add(T item)
        {
            if(_collection.Count = Capacity)
            {
                _ignoreChange = true;
                _collection.RemoveAt(0);
                _ignoreChange = false;
            }
            _collection.Add(item);
            
        }
        
        private void _collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(!_ignoreChange)
            {
                CollectionChanged?.Invoke(this, e);
            }
        }
    }
