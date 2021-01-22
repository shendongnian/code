    var map = Assembly.GetExecutingAssembly().GetTypes()
        .Select(t => new
            {
                Val = t,
                Key = t.GetInterfaces()
                       .Where(i => i.IsGenericType
                           && (i.GetGenericTypeDefinition() == typeof(IFactory<>))
                           && !i.GetGenericArguments()[0].IsGenericParameter)
                       .Select(i => i.GetGenericArguments()[0])
                       .SingleOrDefault()
            })
        .Where(x => x.Key != null)
        .ToDictionary(x => x.Key, x => x.Val);
