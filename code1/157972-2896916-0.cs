    var searchTarget = typeof(ITarget<>);
    var dict = Assembly.GetExecutingAssembly().
        .GetTypes()
        .SelectMany(t => t.GetInterfaces()
                          .Where(i => i.IsGenericType
                              && (i.GetGenericTypeDefinition() == searchTarget)
                              && !i.ContainsGenericParameters),
                    (t, i) => new { Key = i.GetGenericArguments()[0], Value = t })
        .ToDictionary(x => x.Key, x => x.Value);
