    public static bool HasProperty(ExpandoObject expandoObj,
                                   string name)
    {
        return ((IDictionary<string, object>)expandoObj).ContainsKey(name);
    }
