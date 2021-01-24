    public class ItemPropertyChangedNotifyingList<T> : IList<T>, INotifyPropertyChanged where T : INotifyPropertyChanged
    {
        private List<T> _listImplementation = new List<T>();
    
        public void Add(T item)
        {
            item.PropertyChanged += ItemOnPropertyChanged;
            _listImplementation.Add(item);
        }
    
        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return _listImplementation.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _listImplementation).GetEnumerator();
        }
    
        public void Clear()
        {
            _listImplementation.ForEach(x => x.PropertyChanged -= ItemOnPropertyChanged);
            _listImplementation.Clear();
        }
    
        public bool Contains(T item)
        {
            return _listImplementation.Contains(item);
        }
    
        public void CopyTo(T[] array, int arrayIndex)
        {
            _listImplementation.CopyTo(array, arrayIndex);
        }
    
        public bool Remove(T item)
        {
            item.PropertyChanged -= ItemOnPropertyChanged;
            return _listImplementation.Remove(item);
        }
    
        public int Count => _listImplementation.Count;
            
        public bool IsReadOnly => false;
    
        public int IndexOf(T item)
        {
            return _listImplementation.IndexOf(item);
        }
    
        public void Insert(int index, T item)
        {
            item.PropertyChanged += ItemOnPropertyChanged;
            _listImplementation.Insert(index, item);
        }
        
       public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
            _listImplementation[index].PropertyChanged -= ItemOnPropertyChanged;
            _listImplementation.RemoveAt(index);
        }
        
        public T this[int index]
        {
            get => _listImplementation[index];
            set => _listImplementation[index] = value;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
