    public static IDictionary<TKey, TValue> Sort<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        if(dictionary == null)
        {
            throw new ArgumentNullException("dictionary");
        }
        return new SortedDictionary<TKey, TValue>(dictionary);
    }
    public static IDictionary<TKey, TValue> Sort<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer)
    {
        if(dictionary == null)
        {
            throw new ArgumentNullException("dictionary");
        }
        if(comparer == null)
        {
            throw new ArgumentNullException("comparer");
        }
        return new SortedDictionary<TKey, TValue>(dictionary, comparer);
    }
