    public static string GetParameterInfo1<T>(T item) where T : class
    {
        if (item == null)
            return string.Empty;
        var param = item.ToString().TrimStart('{').TrimEnd('}').Split('=');
        return "Parameter: '" + param[0].Trim() +
               "' = " + param[1].Trim();
    }
