    private static bool IsProxy<T>(this IEntity<T> entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        var type = entity.GetType();
        return type.BaseType != null && type.BaseType.BaseType != null
        && type.BaseType.BaseType == typeof(IEntity<T>);
    }
