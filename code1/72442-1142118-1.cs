    typeof(MyClass)
        .GetInterfaces()
        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGeneric<>))
        .SelectMany(i => i.GetGenericArguments())
        .ToArray();
