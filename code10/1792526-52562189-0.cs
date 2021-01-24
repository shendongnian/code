    public T Build<T>(Dictionary<string, string> source)
        where T : new()
    {
        var flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty;
        var properties = typeof(T).GetProperties(flags)
             .Where(p => p.PropertyType == typeof(string));
    
        var missingKeys = properties.Select(p => p.Name).Except(source.Keys);
        if (missingKeys.Any())
            throw new FooException($"These keys not found: {String.Join(", ", missingKeys)}");
    
        var obj = new T();
    
        foreach (var p in properties)
            p.SetValue(obj, source[p.Name]);
    
        return obj;
    }
