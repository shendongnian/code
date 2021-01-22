    /// <summary>
    /// Dictionary which supports duplicates and null entries
    /// </summary>
    /// <typeparam name="TKey">Type of key</typeparam>
    /// <typeparam name="TValue">Type of items</typeparam>
    public class OpenDictionary<TKey, TValue>
    {
        private readonly Lazy<List<TValue>> _nullStorage = new Lazy<List<TValue>>(
            () => new List<TValue>());
        private readonly Dictionary<TKey, List<TValue>> _innerDictionary =
            new Dictionary<TKey, List<TValue>>();
        /// <summary>
        /// Get all entries
        /// </summary>
        public IEnumerable<TValue> Values =>
            _innerDictionary.Values
                .SelectMany(x => x)
                .Concat(_nullStorage.Value);
        /// <summary>
        /// Add an item
        /// </summary>
        public OpenDictionary<TKey, TValue> Add(TKey key, TValue item)
        {
            if (ReferenceEquals(key, null))
                _nullStorage.Value.Add(item);
            else
            {
                if (!_innerDictionary.ContainsKey(key))
                    _innerDictionary.Add(key, new List<TValue>());
                _innerDictionary[key].Add(item);
            }
            return this;
        }
        /// <summary>
        /// Remove an entry by key
        /// </summary>
        public OpenDictionary<TKey, TValue> RemoveEntryByKey(TKey key, TValue entry)
        {
            if (ReferenceEquals(key, null))
            {
                int targetIdx = _nullStorage.Value.FindIndex(x => x.Equals(entry));
                if (targetIdx < 0)
                    return this;
                _nullStorage.Value.RemoveAt(targetIdx);
            }
            else
            {
                if (!_innerDictionary.ContainsKey(key))
                    return this;
                List<TValue> targetChain = _innerDictionary[key];
                int targetIdx = targetChain.FindIndex(x => x.Equals(entry));
                if (targetIdx < 0)
                    return this;
                targetChain.RemoveAt(targetIdx);
            }
            return this;
        }
        /// <summary>
        /// Remove all entries by key
        /// </summary>
        public OpenDictionary<TKey, TValue> RemoveAllEntriesByKey(TKey key)
        {
            if (ReferenceEquals(key, null))
            {
                if (_nullStorage.IsValueCreated)
                    _nullStorage.Value.Clear();
            }       
            else
            {
                if (_innerDictionary.ContainsKey(key))
                    _innerDictionary[key].Clear();
            }
            return this;
        }
        /// <summary>
        /// Try get entries by key
        /// </summary>
        public bool TryGetEntries(TKey key, out IReadOnlyList<TValue> entries)
        {
            entries = null;
            if (ReferenceEquals(key, null))
            {
                if (_nullStorage.IsValueCreated)
                {
                    entries = _nullStorage.Value;
                    return true;
                }
                else return false;
            }
            else
            {
                if (_innerDictionary.ContainsKey(key))
                {
                    entries = _innerDictionary[key];
                    return true;
                }
                else return false;
            }
        }
    }
