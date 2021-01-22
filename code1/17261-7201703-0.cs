    public static T Safe<T>(this T obj) where T : new()
    {
        if (obj == null)
        {
            obj = new T();
        }
        return obj;
    }
