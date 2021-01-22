    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Common.Collections.Generic
    {
        public class Hashtable<TKey, TValue> : IDictionary<TKey, TValue>
            , ICollection<KeyValuePair<TKey, TValue>>
            , IEnumerable<KeyValuePair<TKey, TValue>>
            , IDictionary
            , ICollection
            , IEnumerable
        {
            protected Hashtable _items;
            /// <summary>
            /// Initializes a new, empty instance of the Hashtable class using the default initial capacity, load factor, hash code provider, and comparer.
            /// </summary>
            public Hashtable()
            {
                _items = new Hashtable();
            }
            /// <summary>
            /// Initializes a new, empty instance of the Hashtable class using the specified initial capacity, and the default load factor, hash code provider, and comparer.
            /// </summary>
            /// <param name="capacity">The approximate number of elements that the Hashtable object can initially contain. </param>
            public Hashtable(int capacity)
            {
                _items = new Hashtable(capacity);
            }
            /// <summary>
            /// Actual underlying hashtable object that contains the elements.
            /// </summary>
            public Hashtable Items { get { return _items; } }
            /// <summary>
            /// Adds an element with the specified key and value into the Hashtable.
            /// </summary>
            /// <param name="key">Key of the new element to add.</param>
            /// <param name="value">Value of the new elment to add.</param>
            public void Add(TKey key, TValue value)
            {
                _items.Add(key, value);
            }
            /// <summary>
            /// Adds an element with the specified key and value into the Hashtable.
            /// </summary>
            /// <param name="item">Item containing the key and value to add.</param>
            public void Add(KeyValuePair<TKey, TValue> item)
            {
                _items.Add(item.Key, item.Value);
            }
            void IDictionary.Add(object key, object value)
            {
                this.Add((TKey)key, (TValue)value);
            }
            /// <summary>
            /// Add a list of key/value pairs to the hashtable.
            /// </summary>
            /// <param name="collection">List of key/value pairs to add to hashtable.</param>
            public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            {
                foreach (var item in collection)
                    _items.Add(item.Key, item.Value);
            }
            /// <summary>
            /// Determines whether the Hashtable contains a specific key.
            /// </summary>
            /// <param name="key">Key to locate.</param>
            /// <returns>True if key is found, otherwise false.</returns>
            public bool ContainsKey(TKey key)
            {
                return _items.ContainsKey(key);
            }
            /// <summary>
            /// Determines whether the Hashtable contains a specific key.
            /// </summary>
            /// <param name="item">Item containing the key to locate.</param>
            /// <returns>True if item.Key is found, otherwise false.</returns>
            public bool Contains(KeyValuePair<TKey, TValue> item)
            {
                return _items.ContainsKey(item.Key);
            }
            bool IDictionary.Contains(object key)
            {
                return this.ContainsKey((TKey)key);
            }
            /// <summary>
            /// Gets an ICollection containing the keys in the Hashtable.
            /// </summary>
            public ICollection<TKey> Keys
            {
                get { return _items.ToList<TKey>(); }
            }
            ICollection IDictionary.Keys
            {
                get { return this.Keys.ToList(); }
            }
            /// <summary>
            /// Gets the value associated with the specified key.
            /// </summary>
            /// <param name="key">The key of the value to get.</param>
            /// <param name="value">When this method returns, contains the value associated with the specified key,
            /// if the key is found; otherwise, the default value for the type of the value parameter. This parameter 
            /// is passed uninitialized.</param>
            /// <returns>true if the hashtable contains an element with the specified key, otherwise false.</returns>
            public bool TryGetValue(TKey key, out TValue value)
            {
                value = (TValue)_items[key];
                return (value != null);
            }
            /// <summary>
            /// Gets an ICollection containing the values in the Hashtable.
            /// </summary>
            public ICollection<TValue> Values
            {
                get { return _items.Values.ToList<TValue>(); }
            }
            ICollection IDictionary.Values
            {
                get { return this.Values.ToList(); }
            }
            /// <summary>
            /// Gets or sets the value associated with the specified key.
            /// </summary>
            /// <param name="key">The key whose value to get or set. </param>
            /// <returns>The value associated with the specified key. If the specified key is not found, 
            /// attempting to get it returns null, and attempting to set it creates a new element using the specified key.</returns>
            public TValue this[TKey key]
            {
                get
                {
                    return (TValue)_items[key];
                }
                set
                {
                    _items[key] = value;
                }
            }
            /// <summary>
            /// Removes all elements from the Hashtable.
            /// </summary>
            public void Clear()
            {
                _items.Clear();
            }
            /// <summary>
            /// Copies all key/value pairs in the hashtable to the specified array.
            /// </summary>
            /// <param name="array">Object array to store objects of type "KeyValuePair&lt;TKey, TValue&gt;"</param>
            /// <param name="arrayIndex">Starting index to store objects into array.</param>
            public void CopyTo(Array array, int arrayIndex)
            {
                _items.CopyTo(array, arrayIndex);
            }
            /// <summary>
            /// Copies all key/value pairs in the hashtable to the specified array.
            /// </summary>
            /// <param name="array">Object array to store objects of type "KeyValuePair&lt;TKey, TValue&gt;"</param>
            /// <param name="arrayIndex">Starting index to store objects into array.</param>
            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                _items.CopyTo(array, arrayIndex);
            }
            /// <summary>
            /// Gets the number of key/value pairs contained in the Hashtable.
            /// </summary>
            public int Count
            {
                get { return _items.Count; }
            }
            /// <summary>
            /// Gets a value indicating whether the Hashtable has a fixed size.
            /// </summary>
            public bool IsFixedSize
            {
                get { return _items.IsFixedSize; }
            }
            /// <summary>
            /// Gets a value indicating whether the Hashtable is read-only.
            /// </summary>
            public bool IsReadOnly
            {
                get { return _items.IsReadOnly; }
            }
            /// <summary>
            /// Gets a value indicating whether access to the Hashtable is synchronized (thread safe).
            /// </summary>
            public bool IsSynchronized
            {
                get { return _items.IsSynchronized; }
            }
            /// <summary>
            /// Gets an object that can be used to synchronize access to the Hashtable.
            /// </summary>
            public object SyncRoot
            {
                get { return _items.SyncRoot; }
            }
            /// <summary>
            /// Removes the element with the specified key from the Hashtable.
            /// </summary>
            /// <param name="key">Key of the element to remove.</param>
            public void Remove(TKey key)
            {
                _items.Remove(key);
            }
            /// <summary>
            /// Removes the element with the specified key from the Hashtable.
            /// </summary>
            /// <param name="item">Item containing the key of the element to remove.</param>
            public void Remove(KeyValuePair<TKey, TValue> item)
            {
                this.Remove(item.Key);
            }
            bool IDictionary<TKey, TValue>.Remove(TKey key)
            {
                var numValues = _items.Count;
                _items.Remove(key);
                return numValues > _items.Count;
            }
            bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
            {
                var numValues = _items.Count;
                _items.Remove(item.Key);
                return numValues > _items.Count;
            }
            void IDictionary.Remove(object key)
            {
                _items.Remove(key);
            }
            /// <summary>
            /// Returns an enumerator that iterates through the hashtable.
            /// </summary>
            /// <returns>An enumerator for a list of key/value pairs.</returns>
            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            {
                foreach (DictionaryEntry? item in _items)
                    yield return new KeyValuePair<TKey, TValue>((TKey)item.Value.Key, (TValue)item.Value.Value);
            }
            /// <summary>
            /// Returns an enumerator that iterates through the hashtable.
            /// </summary>
            /// <returns>An enumerator for a list of key/value pairs as generic objects.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            IDictionaryEnumerator IDictionary.GetEnumerator()
            {
                // Very old enumerator that no one uses anymore, not supported.
                throw new NotImplementedException(); 
            }
            object IDictionary.this[object key]
            {
                get
                {
                    return _items[(TKey)key];
                }
                set
                {
                    _items[(TKey)key] = value;
                }
            }
        }
    }
        
