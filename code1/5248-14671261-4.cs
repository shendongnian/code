    GetParameterName2(new { variable });
    public static string GetParameterName2<T>(T item) where T : class
    {
        if (item == null)
            return string.Empty;
        return typeof(T).GetProperties()[0].Name;
    }
