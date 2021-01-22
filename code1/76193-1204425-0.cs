    public static List<IExample> GetExamples()
    {
        return GetInstances<IExample>().ToList();
    }
    private static IEnumerable<T> GetInstances<T>()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.IsClass &&
                           !type.IsAbstract &&
                           type.GetConstructor(Type.EmptyTypes) != null &&
                           typeof (T).IsAssignableFrom(type))
            .Select(type => (T) Activator.CreateInstance(type));
    }
