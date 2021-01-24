	/// <summary>
    /// Helper class to support object graph reference
    /// </summary>
    internal class FamilySerializerCache
    {
        // weak table for serialization
        // ConditionalWeakTable uses ReferenceEquals() rather than GetHashCode() and Equals() methods to do equality checks, so I can use it as a cache during the writing process to overcome the issue with objects that have overridden the GetHashCode() and Equals() methods.
        private ConditionalWeakTable<object, ISurrogateWithReferenceId> _writingTable = new ConditionalWeakTable<object, ISurrogateWithReferenceId>();
        // dictionary for deserialization
        private readonly Dictionary<ISurrogateWithReferenceId, object> _readingDictionary = new Dictionary<ISurrogateWithReferenceId, object>();
        
        private int _referenceIdCounter = 1;
        /// <summary>
        /// Gets the value associated with the specified key during serialization process.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.</param>
        /// <returns>True if the internal dictionary contains an element with the specified key, otherwise False.</returns>
        private bool TryGetCachedObject(object key, out ISurrogateWithReferenceId value)
        {
            return  _writingTable.TryGetValue(key, out value);
        }
        /// <summary>
        /// Gets the value associated with the specified key during deserialization process.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.</param>
        /// <returns>True if the internal dictionary contains an element with the specified key, otherwise False.</returns>
        private bool TryGetCachedObject(ISurrogateWithReferenceId key, out object value)
        {
            return  _readingDictionary.TryGetValue(key, out value);
        }
        /// <summary>
        /// Resets the internal dictionaries and the counter;
        /// </summary>
        public void ResetCache()
        {
            _referenceIdCounter = 1;
            _readingDictionary.Clear();
            // ConditionalWeakTable automatically removes the key/value entry as soon as no other references to a key exist outside the table, but I want to clean it as well.
            _writingTable = new ConditionalWeakTable<object, ISurrogateWithReferenceId>();
        }
        /// <summary>
        /// Adds the specified key and value to the internal dictionary during serialization process.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
        /// <remarks>If the object implements <see cref="ISurrogateWithReferenceId"/> interface then <see cref="ISurrogateWithReferenceId.ReferenceId"/> is updated.</remarks>
        public void AddToCache(object key, ISurrogateWithReferenceId value)
        {
            if (value.ReferenceId == -1)
                value.ReferenceId = _referenceIdCounter++;
            _writingTable.Add(key, value);
        }
        /// <summary>
        /// Adds the specified key and value to the internal dictionary during deserialization process.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
        /// <remarks>If the object implements <see cref="ISurrogateWithReferenceId"/> interface then <see cref="ISurrogateWithReferenceId.ReferenceId"/> is updated.</remarks>
        public void AddToCache(ISurrogateWithReferenceId key, object value)
        {
            if (key.ReferenceId == -1)
                key.ReferenceId = _referenceIdCounter++;
            _readingDictionary.Add(key, value);
        }
        /// <summary>
        /// Gets the <see cref="ISurrogateWithReferenceId"/> associated with the specified object.
        /// </summary>
        /// <param name="obj">The object corresponding to the value to get.</param>
        /// <returns>The related ISurrogateWithReferenceId if presents, otherwise null.</returns>
        public ISurrogateWithReferenceId GetCachedObjectWithReferenceId(object obj)
        {
            if (TryGetCachedObject(obj, out ISurrogateWithReferenceId value))
                return value;
            return null;
        }
        /// <summary>
        /// Gets the object associated with the specified <see cref="ISurrogateWithReferenceId"/>.
        /// </summary>
        /// <param name="surrogateWithReferenceId">The <see cref="ISurrogateWithReferenceId"/> corresponding to the object to get.</param>
        /// <returns>The related object if presents, otherwise null.</returns>
        public object GetCachedObject(ISurrogateWithReferenceId surrogateWithReferenceId)
        {
            if (TryGetCachedObject(surrogateWithReferenceId, out object value))
                return value;
            return null;
        }
    }
