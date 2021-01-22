    public class OrderedList<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary
        {
            private readonly Dictionary<TKey, int> _order;
            private readonly SortedList<TKey, TValue> _internalList;
    
            private readonly bool _sorted;
            private readonly OrderComparer _comparer;
    
            public OrderedList(IDictionary<TKey, TValue> dictionary, bool sorted = false)
            {
                _sorted = sorted;
    
                if (dictionary == null) dictionary = new Dictionary<TKey, TValue>();
    
                if (_sorted)
                {
                    _internalList = new SortedList<TKey, TValue>(dictionary);
                }
                else
                {
                    _order = new Dictionary<TKey, int>();
                    _comparer = new OrderComparer(ref _order);
                    _internalList = new SortedList<TKey, TValue>(_comparer);
                    // keep prder of the IDictionary
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
                private readonly Dictionary<TKey, int> _order;
    
                public OrderComparer(ref Dictionary<TKey, int> order)
                {
                    _order = order;
                }
    
                public override int Compare(TKey x, TKey y)
                {
                    var xo = _order[x];
                    var yo = _order[y];
                    return xo.CompareTo(yo);
                }
            }
    
            public void Add(TKey key, TValue value)
            {
                if (!_sorted) _order.Add(key, _order.LastOrDefault().Value + 1);
                _internalList.Add(key, value);
            }
    
            public bool Remove(TKey key)
            {
                if (!_sorted) _order.Remove(key);
                return _internalList.Remove(key);
            }
    
            // Other IDictionary<> + IDictionary members implementation wrapping around _internalList
            // ...
        }
