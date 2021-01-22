    [Serializable]
    public class XmlSerializableDictionary<TKey, TValue>: Dictionary<TKey, TValue> {
        public void Add(KeyValuePair<TKey, TValue> entry) {
            this.Add(entry.Key, entry.Value);
        }
    }
