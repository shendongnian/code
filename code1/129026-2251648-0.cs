    public class PartitionList<T> : IList<T> {
        private readonly int _maxCountPerList;
        private readonly IList<IList<T>> _lists;
    
        public PartitionList(int maxCountPerList) {
            _maxCountPerList = maxCountPerList;
            _lists = new List<IList<T>> { new List<T>() };
        }
    
        public IEnumerator<T> GetEnumerator() {
            return _lists.SelectMany(list => list).GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    
        public void Add(T item) {
            var lastList = _lists[_lists.Count - 1];
            if (lastList.Count == _maxCountPerList) {
                lastList = new List<T>();
                _lists.Add(lastList);
            }
            lastList.Add(item);
        }
    
        public void Clear() {
            while (_lists.Count > 1) _lists.RemoveAt(1);
            _lists[0].Clear();
        }
    
        public bool Contains(T item) {
            return _lists.Any(sublist => sublist.Contains(item));
        }
    
        public void CopyTo(T[] array, int arrayIndex) {
            // Homework
            throw new NotImplementedException();
        }
    
        public bool Remove(T item) {
            // Evil, Linq with sideeffects
            return _lists.Any(sublist => sublist.Remove(item));
        }
    
        public int Count {
            get { return _lists.Sum(subList => subList.Count); }
        }
    
        public bool IsReadOnly {
            get { return false; }
        }
    
        public int IndexOf(T item) {
            int index = _lists.Select((subList, i) => subList.IndexOf(item) * i).Max();
            return (index > -1) ? index : -1;
        }
    
        public void Insert(int index, T item) {
            // Homework
            throw new NotImplementedException();
        }
    
        public void RemoveAt(int index) {
            // Homework
            throw new NotImplementedException();
        }
    
        public T this[int index] {
            get {
                if (index >= _lists.Sum(subList => subList.Count)) {
                    throw new IndexOutOfRangeException();
                }
                var list = _lists[index / _maxCountPerList];
                return list[index % _maxCountPerList];
            }
            set {
                if (index >= _lists.Sum(subList => subList.Count)) {
                    throw new IndexOutOfRangeException();
                }
                var list = _lists[index / _maxCountPerList];
                list[index % _maxCountPerList] = value;
            }
        }
    }
