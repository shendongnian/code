       public static bool IsTheGenericType(this Type candidateType, Type genericType)
        {
            return
                candidateType != null && genericType != null &&
                (candidateType.IsGenericType && candidateType.GetGenericTypeDefinition() == genericType ||
                 candidateType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType) ||
                 candidateType.BaseType != null && candidateType.BaseType.IsTheGenericType(genericType));
        }
