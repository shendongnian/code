    public class Entry<TKey>
    {
        TKey key;
        Dictionary<TKey, WeakReference> weakDictionary;
        public Entry(Dictionary<TKey, WeakReference> weakDictionary, TKey key)
        {
            this.key = key;
            this.weakDictionary = weakDictionary;
        }
        ~Entry()
        {
            weakDictionary.Remove(key);
        }
    }
