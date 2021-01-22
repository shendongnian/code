    [Serializable]
    public class SerializableDictionary<TKey, TValue>
    {
        /// <summary>
        /// List of serializable dictionary entries.
        /// </summary>
        [XmlElement("Entry")]
        public List<KeyAndValue<TKey, TValue>> Entries { get; set; }
        /// <summary>
        /// Serializable key-value pair.
        /// </summary>
        [Serializable]
        public class KeyAndValue<TKey, TValue>
        {
            /// <summary>
            /// Key that is mapped to a value.
            /// </summary>
            public TKey Key { get; set; }
            /// <summary>
            /// Value the key is mapped to.
            /// </summary>
            public TValue Value { get; set; }
        }
    }
