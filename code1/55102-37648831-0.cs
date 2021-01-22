    public class DictionaryBindingList<TKey, TValue> : BindingList<KeyValuePair<TKey, TValue>>
    {
        public readonly IDictionary<TKey, TValue> Dictionary;
        public DictionaryBindingList()
        {
            Dictionary = new Dictionary<TKey, TValue>();
        }
        public void Add(TKey key, TValue value)
        {
            base.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
        
        public void Remove(TKey key)
        {
            var item = this.First(x => x.Key.Equals(key));
            base.Remove(item);
        }
        
        protected override void InsertItem(int index, KeyValuePair<TKey, TValue> item)
        {
            Dictionary.Add(item.Key, item.Value);
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            Dictionary.Remove(this[index].Key);
            base.RemoveItem(index);
        }
        public int IndexOf(TKey key)
        {
            var item = this.FirstOrDefault(x => x.Key.Equals(key));
            return item.Equals(null) ? -1 : base.IndexOf(item);
        }
    }
