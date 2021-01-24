    var type = typeof(ISomeInterface);
    var types = assembly.GetTypes().Where(t =>
                    type.IsAssignableFrom(t) &&
                    t.GetTypeInfo().IsClass &&
                    !t.GetTypeInfo().IsAbstract);
    var targetType = types.Single();
