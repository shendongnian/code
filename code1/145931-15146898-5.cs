    public class OrderedList<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary
    {
        private readonly Dictionary<TKey, int> _order;
        private readonly SortedList<TKey, TValue> _internalList;
        private readonly bool _sorted;
        private readonly OrderComparer _comparer;
        public OrderedList(IDictionary<TKey, TValue> dictionary, bool sorted = false)
        {
            _sorted = sorted;
            if (dictionary == null)
                dictionary = new Dictionary<TKey, TValue>();
            if (_sorted)
            {
                _internalList = new SortedList<TKey, TValue>(dictionary);
            }
            else
            {
                _order = new Dictionary<TKey, int>();
                _comparer = new OrderComparer(ref _order);
                _internalList = new SortedList<TKey, TValue>(_comparer);
                // Keep order of the IDictionary
                foreach (var kvp in dictionary)
                {
                    Add(kvp);
                }
            }
        }
        public OrderedList(bool sorted = false)
            : this(null, sorted)
        {
        }
        private class OrderComparer : Comparer<TKey>
        {
            public Dictionary<TKey, int> Order { get; set; }
            public OrderComparer(ref Dictionary<TKey, int> order)
            {
                Order = order;
            }
            public override int Compare(TKey x, TKey y)
            {
                var xo = Order[x];
                var yo = Order[y];
                return xo.CompareTo(yo);
            }
        }
        private void ReOrder()
        {
            var i = 0;
            _order = _order.OrderBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => i++);
            _comparer.Order = _order;
            _lastOrder = _order.Values.Max() + 1;
        }
        public void Add(TKey key, TValue value)
        {
            if (!_sorted)
            {
                _order.Add(key, _lastOrder);
                _lastOrder++;
                // Very rare event
                if (_lastOrder == int.MaxValue)
                    ReOrder();
            }
            _internalList.Add(key, value);
        }
        public bool Remove(TKey key)
        {
            var result = _internalList.Remove(key);
            if (!_sorted)
                _order.Remove(key);
            return result;
        }
        // Other IDictionary<> + IDictionary members implementation wrapping around _internalList
        // ...
    }
