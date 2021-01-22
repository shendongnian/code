    public static string GetParameterInfo2<T>(T item) where T : class
    {
        if (item == null)
            return string.Empty;
        var param = typeof(T).GetProperties()[0];
        return "Parameter: '" + param.Name +
               "' = " + param.GetValue(item, null);
    }
