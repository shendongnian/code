    public static class MultimapExt
    {
        public static void Add<TKey, TValue, TCollection>( 
            this IDictionary<TKey, TCollection> dictionary,
            TKey key,
            TValue value
        ) where TCollection : ICollection<TValue>, new()
        {
            TCollection collection;
            if(!dictionary.TryGetValue(key, out collection)
            {
                collection = new TCollection();
                dictionary.Add(key, collection);
            }
    
            collection.Add(value);
        }
    
        public static bool Remove<TKey, TValue, TCollection>(
            this IDictionary<TKey, TCollection> dictionary,
            TKey key,
            TValue value
        ) where TCollection : ICollection<TValue>
        {
            TCollection collection;
            if(dictionary.TryGetValue(key, out collection))
            {
                bool removed = collection.Remove(value);
    
                if(collection.Count == 0)
                   dictionary.Remove(key);
    
                return removed;
            }
    
            return false;
        }
    }
