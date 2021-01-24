    public static Dictionary<TKey, TValue> Copy>Tkey, TValue>(
        this Dictionary<TKey, TValue> source)
    {
         return source.ToDictionary(x => x.Key, x => x.Value);
    }
    public static void AddRange<TKey, TValue>(
        this Dictionary<TKey, TValue> destination,
        Dictionary<TKey, TValue> source)
    {
         foreach (var keyValuePair in source)
         {
             destination.Add(keyValuePair.Key, keyValuePair.Value);
             // TODO: decide what to do if Key already in Destination
         }
    }
