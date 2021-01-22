    private static class Container<T> where T : struct
    {
        public static Dictionary<string, T> Dict = new Dictionary<string, T>();
    }
    public bool TryGetValue<T>(string key, out T value) where T : struct
    {
        return Container<T>.Dict.TryGetValue(key, out value);
    }
