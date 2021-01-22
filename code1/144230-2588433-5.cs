    public class XmlDictionaryEntryCollection<TKey, TValue> : ICollection<XmlDictionaryEntry<TKey, TValue>>
    {
        public XmlDictionaryEntryCollection()
        {
            this.Dictionary = new Dictionary<TKey, TValue>();
        }
        public XmlDictionaryEntryCollection(IDictionary<TKey, TValue> dictionary)
        {
            dictionary.CheckArgumentNull("dictionary");
            this.Dictionary = dictionary;
        }
        [XmlIgnore]
        public IDictionary<TKey, TValue> Dictionary { get; private set; }
        #region ICollection<XmlDictionaryEntry<TKey,TValue>> Members
        public void Add(XmlDictionaryEntry<TKey, TValue> item)
        {
            this.Dictionary.Add(item.Key, item.Value);
        }
        public void Clear()
        {
            this.Dictionary.Clear();
        }
        public bool Contains(XmlDictionaryEntry<TKey, TValue> item)
        {
            return this.Dictionary.ContainsKey(item.Key);
        }
        public void CopyTo(XmlDictionaryEntry<TKey, TValue>[] array, int arrayIndex)
        {
            int index = arrayIndex;
            if (arrayIndex + this.Dictionary.Count > array.Length)
                throw new ArgumentException(ExceptionMessages.CopyToNotEnoughSpace);
            foreach (var kvp in this.Dictionary)
            {
                var entry = new XmlDictionaryEntry<TKey, TValue>
                {
                    Key = kvp.Key,
                    Value = kvp.Value
                };
                array[index++] = entry;
            }
        }
        public int Count
        {
            get { return this.Dictionary.Count; }
        }
        public bool IsReadOnly
        {
            get { return this.Dictionary.IsReadOnly; }
        }
        public bool Remove(XmlDictionaryEntry<TKey, TValue> item)
        {
            return this.Dictionary.Remove(item.Key);
        }
        #endregion
        #region IEnumerable<XmlDictionaryEntry<TKey,TValue>> Members
        public IEnumerator<XmlDictionaryEntry<TKey, TValue>> GetEnumerator()
        {
            foreach (var kvp in this.Dictionary)
            {
                yield return new XmlDictionaryEntry<TKey, TValue>
                {
                    Key = kvp.Key,
                    Value = kvp.Value
                };
            }
        }
        #endregion
        #region IEnumerable Members
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
