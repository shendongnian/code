    GetParameterName1(new { variable });
    public static string GetParameterName1<T>(T item) where T : class
    {
        if (item == null)
            return string.Empty;
        return item.ToString().TrimStart('{').TrimEnd('}').Split('=')[0].Trim();
    }
