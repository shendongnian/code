    static void Transform<T>(T t)
        where T: class
    {
        if (ReferenceEquals(t, null))
            throw new ArgumentNullException(nameof(t));
        var propertiesToEdit =
            typeof(T).GetProperties(BindingFlags.Public |
                                    BindingFlags.Instance)
                     .Where(p => p.PropertyType == typeof(string)
                                 p.CanWrite &&
                                 p.CanRead);
       
        foreach (var p in propertiesToEdit)
        {
            p.SetValue(t, $"\"{p.GetValue(t)}\"");
        }
    }
