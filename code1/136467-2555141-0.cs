    public static T ChangeType<T>(this object obj) where T : new()
    {
        try
        {
            Type type = typeof(T);
            return (T)Convert.ChangeType(obj, type);
        }
        catch
        {
            return new T();
        }
    }
