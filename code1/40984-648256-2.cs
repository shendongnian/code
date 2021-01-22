    public static T Parse<T>(string value)
    {
        // or ConvertFromInvariantString if you are doing serialization
        return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
    }
