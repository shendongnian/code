    private static Type SafeGetSingleGenericParameter(Type type, Type interfaceType)
        {
            if (!interfaceType.IsGenericType || interfaceType.GetGenericArguments().Count() != 1)
                return type;
            foreach (Type baseInterface in type.GetInterfaces())
            {
                if (baseInterface.IsGenericType &&
                    baseInterface.GetGenericTypeDefinition() == interfaceType.GetGenericTypeDefinition())
                {
                    return baseInterface.GetGenericArguments().Single();
                }
            }
            return type;
        }
