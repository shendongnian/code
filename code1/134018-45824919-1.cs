    public class Lookup<TKey, TElement> 
      : Collection<TElement>, ILookup<TKey, TElement>
    {
      public MultiValueDictionary(Func<TElement, TKey> keyForItem) 
        : base((IList<TElement>)new Collection(keyForItem))
      {
      }
      new Collection Items => (Collection)base.Items;
      public IEnumerable<TElement> this[TKey key] => Items[key];
      public bool Contains(TKey key) => Items.Contains(key);
      IEnumerator<IGrouping<TKey, TElement>> 
        IEnumerable<IGrouping<TKey, TElement>>.GetEnumerator() => Items.GetEnumerator();
      class Collection : KeyedCollection<TKey, Grouping>
      {
        Func<TElement, TKey> KeyForItem { get; }
        public bool IsReadOnly => throw new NotImplementedException();
        public Collection(Func<TElement, TKey> keyForItem) => KeyForItem = keyForItem;
        protected override TKey GetKeyForItem(Grouping item) => item.Key;
        public void Add(TElement item)
        {
          var key = KeyForItem(item);
          if (Dictionary != null && Dictionary.TryGetValue(key, out var collection))
            collection.Add(item);
          else
            Add(new Grouping(key) { item });
        }
        public bool Remove(TElement item)
        {
          var key = KeyForItem(item);
          if (Dictionary != null && Dictionary.TryGetValue(key, out var collection)
            && collection.Remove(item))
          {
            if (collection.Count == 0)
              Remove(key);
            return true;
          }
          return false;
        }
      }
      class Grouping : Collection<TElement>, IGrouping<TKey, TElement>
      {
        public Grouping(TKey key) => Key = key;
        public TKey Key { get; }
      }
    }
