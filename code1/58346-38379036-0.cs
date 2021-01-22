    public static Type GetGenericElementType(this Type type)
    {
        // Short-circuit for Array types
        if (typeof(Array).IsAssignableFrom(type))
        {
            return type.GetElementType();
        }
        while (true)
        {
            // Type is IEnumerable<T>
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return type.GetGenericArguments().First();
            }
            // Type implements/extends IEnumerable<T>
            Type elementType = (from subType in type.GetInterfaces()
                let retType = subType.GetGenericElementType()
                where retType != subType
                select retType).FirstOrDefault();
            if (elementType != null)
            {
                return elementType;
            }
            if (type.BaseType == null)
            {
                return type;
            }
            type = type.BaseType;
        }
    }
