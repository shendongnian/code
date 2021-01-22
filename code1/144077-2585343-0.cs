    public static void GetValueAs<T, R>(this IDictionary<string, R> dictionary, string fieldName, out T value)
        where T : R
    {
        value = default(T);
        dictionary.TryGetValue(fieldName, out value)
    }
