    public static int FindFirstIndexGreaterThanOrEqualTo<K, V>(
            this SortedList<K, V> sortedCollection, K key
        ) where V : new()
    {
        if (sortedCollection.ContainsKey(key))
        {
            return sortedCollection.IndexOfKey(key);
        }
        sortedCollection[key] = new V();
        int retval = sortedCollection.IndexOfKey(key);
        sortedCollection.Remove(key);
        return retval;
    }
