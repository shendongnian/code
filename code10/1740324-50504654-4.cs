    public static T GetValue<T>(this Dictionary<string, object> dictionary, string key)
    {
        if (dictionary == null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }
    
        if (!dictionary.ContainsKey(key))
        {
            return default(T); //Or null, depending on you needs
        }
    
        var value = dictionary[key];
    
        if (value == null)
        {
            return default(T);
        }
    
        if (value is IConvertible)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    
        return (T)value;
    }
