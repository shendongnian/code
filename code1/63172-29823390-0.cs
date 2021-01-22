    public static bool IsOfGenericType(this Type typeToCheck, Type genericType)
    {
        while (true)
        {
            if (genericType == null)
                throw new ArgumentNullException("genericType");
            if (!genericType.IsGenericTypeDefinition)
                throw new ArgumentException("The definition needs to be a GenericTypeDefinition", "genericType");
            if (typeToCheck == null || typeToCheck == typeof(object))
                return false;
            if (typeToCheck == genericType)
                return true;
            if ((typeToCheck.IsGenericType ? typeToCheck.GetGenericTypeDefinition() : typeToCheck) == genericType)
                return true;
            if (genericType.IsInterface)
                return typeToCheck.GetInterfaces().Any(i => i.IsOfGenericType(genericType));
            typeToCheck = typeToCheck.BaseType;
        }
    }
    public static bool IsOfGenericType(this Type typeToCheck, Type genericType, out Type concreteGenericType)
    {
        while (true)
        {
            concreteGenericType = null;
            if (genericType == null)
                throw new ArgumentNullException("genericType");
            if (!genericType.IsGenericTypeDefinition)
                throw new ArgumentException("The definition needs to be a GenericTypeDefinition", "genericType");
            if (typeToCheck == null || typeToCheck == typeof(object))
                return false;
            if (typeToCheck == genericType)
            {
                concreteGenericType = typeToCheck;
                return true;
            }
            if ((typeToCheck.IsGenericType ? typeToCheck.GetGenericTypeDefinition() : typeToCheck) == genericType)
            {
                concreteGenericType = typeToCheck;
                return true;
            }
            if (genericType.IsInterface)
            {
                foreach (var i in typeToCheck.GetInterfaces())
                {
                    if (i.IsOfGenericType(genericType, out concreteGenericType))
                    {
                        return true;
                    }
                }
            }
            typeToCheck = typeToCheck.BaseType;
        }
    }
