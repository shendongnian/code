    /// <summary>
    /// Read only wrapper for generics based dictionary.
    /// Only provides lookup retrieval abilities.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DictionaryReadOnly<TKey, TValue> : IDictionary<TKey, TValue>
    {
        #region Private Members
        private IDictionary<TKey, TValue> _item;
        private bool _throwOnWritableAction = false;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor requiring the generic dictionary being wrapped.
        /// </summary>
        /// <param name="item"></param>
        public DictionaryReadOnly(IDictionary<TKey, TValue> items)
        {
            _throwOnWritableAction = true;
            _item = items;
        }
        /// <summary>
        /// Constructor requiring the generic dictionary being wrapped.
        /// </summary>
        /// <param name="item"></param>
        public DictionaryReadOnly(IDictionary<TKey, TValue> items, bool throwOnWritableAction)
        {            
            _throwOnWritableAction = throwOnWritableAction;
            _item = items;
        }
        #endregion
        #region IDictionary<TKey,TValue> Members
        /// <summary>
        /// Number of items in the dictionary.
        /// </summary>
        public int Count
        {
            get { return _item.Count; }
        }
        /// <summary>
        /// Determine if the underlying collection contains the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            return _item.ContainsKey(key);
        }
        /// <summary>
        /// Returns the value associated with the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get { return _item[key]; }
            set
            {
                CheckAndThrow("Set");
            }
        }
        /// <summary>
        /// Return keys.
        /// </summary>
        public ICollection<TKey> Keys
        {
            get { return _item.Keys; }
        }
        /// <summary>
        /// Not-supported.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            CheckAndThrow("Add");
        }
        /// <summary>
        /// Not-supported.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            CheckAndThrow("Remove");
            return false;
        }
        /// <summary>
        /// Try to get the value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            if (_item.ContainsKey(key))
            {
                value = _item[key];
                return true;
            }
            return false;
        }
        /// <summary>
        /// Get the values.
        /// </summary>
        public ICollection<TValue> Values
        {
            get { return _item.Values; }
        }
        #endregion
        #region ICollection<KeyValuePair<TKey,TValue>> Members
        /// <summary>
        /// Not-supported.
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            CheckAndThrow("Add");
        }
        /// <summary>
        /// Not-Supported.
        /// </summary>
        public void Clear()
        {
            CheckAndThrow("Clear");
        }
        /// <summary>
        /// Determine whether key value pair is in dictionary.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _item.Contains(item);
        }
        /// <summary>
        /// Copy items to the array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            this._item.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Indicate read-only
        /// </summary>
        public bool IsReadOnly
        {
            get { return true; }
        }
        /// <summary>
        /// Non-supported action.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            CheckAndThrow("Remove");
            return false;
        }
        #endregion
        #region IEnumerable<KeyValuePair<TKey,TValue>> Members
        /// <summary>
        /// Get the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _item.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        /// <summary>
        /// Get the enumerator.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _item.GetEnumerator();
        }
        #endregion
        /// <summary>
        /// Check and thrown based on flag.
        /// </summary>
        /// <param name="action"></param>
        void CheckAndThrow(string action)
        {
            if (_throwOnWritableAction)
                throw new InvalidOperationException("Can not perform action : " + action + " on this read-only collection.");
        }
    }
