    public class SortedMultiSet<T> : IEnumerable<T>
    {
        private SortedDictionary<T, int> _dict; 
        public SortedMultiSet()
        {
            _dict = new SortedDictionary<T, int>();
        }
        public SortedMultiSet(IEnumerable<T> items) : this()
        {
            Add(items);
        }
        public bool Contains(T item)
        {
            return _dict.ContainsKey(item);
        }
        public void Add(T item)
        {
            if (_dict.ContainsKey(item))
                _dict[item]++;
            else
                _dict[item] = 1;
        }
        public void Add(IEnumerable<T> items)
        {
            foreach (var item in items)
                Add(item);
        }
        public void Remove(T item)
        {
            if (!_dict.ContainsKey(item))
                throw new ArgumentException();
            if (--_dict[item] == 0)
                _dict.Remove(item);
        }
        // Return the last value in the multiset
        public T Peek()
        {
            if (!_dict.Any())
                throw new NullReferenceException();
            return _dict.Last().Key;
        }
        // Return the last value in the multiset and remove it.
        public T Pop()
        {
            T item = Peek();
            Remove(item);
            return item;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach(var kvp in _dict)
                for(int i = 0; i < kvp.Value; i++)
                    yield return kvp.Key;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
