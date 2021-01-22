    public static IEnumerable<Type> GetSubtypes(Assembly assembly, Type parent)
    {
        return assembly.GetTypes()
                       .Where(type => typeof(parent).IsAssignableFrom(type));
    }
