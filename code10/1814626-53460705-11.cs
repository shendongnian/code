    static void Transform<T, Q>(T t, Func<Q, Q> transform)
        where T: class
    {
        if (ReferenceEquals(t, null))
           throw new ArgumentNullException(nameof(t));
        var propertiesToEdit = 
            typeof(T).GetProperties(BindingFlags.Public |
                                    BindingFlags.Instance)
                     .Where(p => p.CanWrite &&
                                 p.PropertyType == typeof(Q));
            
        foreach (var p in propertiesToEdit)
        {
            p.SetValue(t, transform((Q)p.GetValue(t)));
        }
    }
