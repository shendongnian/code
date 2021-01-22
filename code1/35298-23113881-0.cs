    public static Type GetCollectionItemType(Type collectionType)
    {
        var types = collectionType.GetInterfaces()
            .Where(x => x.IsGenericType 
                && x.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .ToArray();
        // Only support collections that implement IEnumerable<T> once.
        return types.Length == 1 ? types[0].GetGenericArguments()[0] : null;
    }
