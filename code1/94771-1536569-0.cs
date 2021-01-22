    Type type = value.GetType();
    if (!type.IsGenericType())
    {
        throw new ArgumentException("Not a generic type");
    }
    if (type.GetGenericTypeDefinition() != typeof(Foo<>))
    {
        throw new ArgumentException("Not the right generic type");
    }
