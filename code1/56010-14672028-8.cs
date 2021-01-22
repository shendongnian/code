    public static void ThrowIfNull<T>(this T item) where T : class
    {
        if (item == null)
            return;
        var param = typeof(T).GetProperties()[0];
        if (param.GetValue(item, null) == null)
            throw new ArgumentNullException(param.Name);
    }
