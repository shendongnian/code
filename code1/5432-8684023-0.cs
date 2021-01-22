    public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
    {
      return givenType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == genericType) ||
             givenType.BaseType != null && (givenType.BaseType.IsGenericType && givenType.BaseType.GetGenericTypeDefinition() == genericType ||
                                            givenType.BaseType.IsAssignableToGenericType(genericType));
    }
