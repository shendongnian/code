    public static T BindValues<T>(RouteValueDictionary values)
        where T : new()
    {
        var obj = new T();
        foreach (var prop in typeof(T).GetProperties())
        {
            if (values.ContainsKey(prop.Name))
            {
                prop.SetValue(obj, values[prop.Name]);
            }
        }
        return obj;
    }
