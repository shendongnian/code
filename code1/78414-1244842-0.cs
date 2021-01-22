    private static readonly Dictionary<Type,Dictionary<string,object>> _cache 
        = new Dictionary<Type, IDictionary>();
    //The generic parameter allow null values to be cached
    private static void AddToCache<T>(string key, T value)
    {
        // create a dictionary of the correct type
        if(!_cache.ContainsKey(typeof(T)))
            _cache.Add(typeof(T),new Dictionary<string, T>());
        _cache[typeof (T)][key] = value;
    }
    private static T GetFromCache<T>(string key)
    {
        // casting the dictionary instead of the value
        Dictionary<string, T> typedDictionary = (Dictionary<string, T>)_cache[typeof (T)];
        return typedDictionary[key];
    }
