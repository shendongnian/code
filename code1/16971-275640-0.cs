    /// <summary>
    /// If a key exists in a dictionary, return its value, 
    /// otherwise return the default value for that type.
    /// </summary>
    public static U GetWithDefault<T, U>(this Dictionary<T, U> dict, T key)
    {
        return dict.GetWithDefault(key, default(U));
    }
    /// <summary>
    /// If a key exists in a dictionary, return its value,
    /// otherwise return the provided default value.
    /// </summary>
    public static U GetWithDefault<T, U>(this Dictionary<T, U> dict, T key, U defaultValue)
    {
        return dict.ContainsKey(key)
            ? dict[key]
            : defaultValue;
    }
