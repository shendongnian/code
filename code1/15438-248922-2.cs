    static Type GetGenericCollectionItemType(Type type)
    {
        return type.GetInterfaces()
            .Where(face => face.IsGenericType &&
                           face.GetGenericTypeDefinition() == typeof(ICollection<>))
            .Select(face => face.GetGenericArguments()[0])
            .FirstOrDefault();
    }
