    var map = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(a => a.GetTypes())
        .Select(t => new
        {
            Value = t,
            Key   = t.GetInterfaces()
                     .Where(i => i.IsGenericType
                         && (i.GetGenericTypeDefinition() == typeof(IFactory<>))
                         && !i.GetGenericArguments()[0].IsGenericParameter)
                     .Select(i => i.GetGenericArguments()[0])
                     .FirstOrDefault()
        })
        .Where(x => x.Key != null)
        .ToDictionary(x => x.Key, x => x.Value);
