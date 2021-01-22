    public static bool ImplementsInterface(this Type type, Type interfaceType)
    {
        while (type != null && type != typeof(object))
        {
            if (type.GetInterfaces().Any(@interface => 
                @interface.IsGenericType
                && @interface.GetGenericTypeDefinition() == interfaceType))
            {
                return true;
            }
            type = type.BaseType;
        }
        return false;
    }
