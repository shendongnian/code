    public class OcPropertyChangedListener<T> : INotifyPropertyChanged where T : INotifyPropertyChanged
    {
        private readonly ObservableCollection<T> _collection;
        private readonly string _propertyName;
        private readonly Dictionary<T, int> _items = new Dictionary<T, int>(new ObjectIdentityComparer());
        public OcPropertyChangedListener(ObservableCollection<T> collection, string propertyName = "")
        {
            _collection = collection;
            _propertyName = propertyName ?? "";
            AddRange(collection);
            CollectionChangedEventManager.AddHandler(collection, CollectionChanged);
        }
     
        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddRange(e.NewItems.Cast<T>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveRange(e.OldItems.Cast<T>());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    AddRange(e.NewItems.Cast<T>());
                    RemoveRange(e.OldItems.Cast<T>());
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Reset();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
     
        }
     
        private void AddRange(IEnumerable<T> newItems)
        {
            foreach (T item in newItems)
            {
                if (_items.ContainsKey(item))
                {
                    _items[item]++;
                }
                else
                {
                    _items.Add(item, 1);
                    PropertyChangedEventManager.AddHandler(item, ChildPropertyChanged, _propertyName);
                }
            }
        }
     
        private void RemoveRange(IEnumerable<T> oldItems)
        {
            foreach (T item in oldItems)
            {
                _items[item]--;
                if (_items[item] == 0)
                {
                    _items.Remove(item);
                    PropertyChangedEventManager.RemoveHandler(item, ChildPropertyChanged, _propertyName);
                }
            }
        }
     
        private void Reset()
        {
            foreach (T item in _items.Keys.ToList())
            {
                PropertyChangedEventManager.RemoveHandler(item, ChildPropertyChanged, _propertyName);
                _items.Remove(item);
            }
            AddRange(_collection);
        }
     
        public event PropertyChangedEventHandler PropertyChanged;
     
        protected virtual void ChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(sender, e);
        }
     
        private class ObjectIdentityComparer : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                return object.ReferenceEquals(x, y);
            }
            public int GetHashCode(T obj)
            {
                return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
            }
        }
    }
     
    public static class OcPropertyChangedListener
    {
        public static OcPropertyChangedListener<T> Create<T>(ObservableCollection<T> collection, string propertyName = "") where T : INotifyPropertyChanged
        {
            return new OcPropertyChangedListener<T>(collection, propertyName);
        }
    }
