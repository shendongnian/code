    public abstract class Lookup<TKey, TElement> : KeyedCollection<TKey, ICollection<TElement>>
    {
      protected override TKey GetKeyForItem(ICollection<TElement> item) =>
        item
        .Select(b => GetKeyForItem(b))
        .Distinct()
        .SingleOrDefault();
      protected abstract TKey GetKeyForItem(TElement item);
      public void Add(TElement item)
      {
        var key = GetKeyForItem(item);
        if (Dictionary != null && Dictionary.TryGetValue(key, out var collection))
          collection.Add(item);
        else
          Add(new List<TElement> { item });
      }
      public void Remove(TElement item)
      {
        var key = GetKeyForItem(item);
        if (Dictionary != null && Dictionary.TryGetValue(key, out var collection))
        {
          collection.Remove(item);
          if (collection.Count == 0)
            Remove(key);
        }
      }
    }
