    public static class ConversionAssistants
    {
        public static bool GenericImplementsType(this IEnumerable objects, Type baseType)
        {
            foreach (Type type in objects.GetType().GetInterfaces())
            {
                if (type.IsGenericType)
                {
                    if (type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        if (baseType.IsAssignableFrom(type.GetGenericArguments()[0]))
                            return true;
                    }
                }
            }
            return false;
        }
    }
