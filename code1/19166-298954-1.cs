    class IndexableDictionary<TKey, TItem> : KeyedCollection<TKey, TItem>
     { Dictionary<TItem, TKey> keys = new Dictionary<TItem, TKey>();
       protected override TKey GetKeyForItem(TItem item) { return keys[item];}
       
       public void Add(TKey key, TItem item) 
        { keys[item] = key;
          this.Add(item);
        }
     }
