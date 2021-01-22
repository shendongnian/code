    /// <summary>
    /// Returns all types in the current AppDomain
    /// </summary>
    public static IEnumerable<Type> LoadedType()
    {
        return AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes());
    }
