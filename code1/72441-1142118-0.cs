    typeof(MyClass)
        .GetInterfaces()
        .Where(i => i.IsGenericType)
        .SelectMany(i => i.GetGenericArguments())
        .ToArray();
