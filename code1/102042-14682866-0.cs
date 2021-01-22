    public static string GetName<T>(this T item) where T : class
    {
        if (item == null)
            return string.Empty;
        return typeof(T).GetProperties()[0].Name;
    }
