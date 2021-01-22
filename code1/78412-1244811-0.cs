    static class Helper<T>
    {
           internal static readonly Dictionary<string, T> cache = new Dictionary<string, T>();
    }
    private static void AddToCache<T>(string key, T value)
    {
       Helper<T>.cache[key] = value;
    }
    private static T GetFromCache<T>(string key)
    {
        return Helper<T>.cache[key];
    }
