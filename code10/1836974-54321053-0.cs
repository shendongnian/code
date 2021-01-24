    public static bool HasGenericInterface(this Type @type,Type genericInterface)
    {
     var allInterfaces = @type.GetInterfaces();
     return allInterfaces
            .Where(i => i.IsGenericType)
            .Select(i => i.GetGenericTypeDefinition())
            .Any(i => i.IsAssignableFrom(genericInterface));
     }
