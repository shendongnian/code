    public static object GetData<T>(IQueryable<T> data)
    {
        Type t = data.GetType().GenericTypeArguments[0];
        ...
    }
