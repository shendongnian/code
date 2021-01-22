    public class MySortedList<TKey, TValue> : IDictionary<TKey, TValue>, 
        ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, 
        IDictionary, ICollection, IEnumerable, INotifyCollectionChanged
    {
        private SortedList<TKey, TValue> internalList = new SortedList<TKey, TValue>();
        public void Add(TKey key, TValue value)
        {
            this.internalList.Add(key,value);
            // Do your change tracking
        }
        // ... implement other methods, just passing to internalList, plus adding your logic
    }
