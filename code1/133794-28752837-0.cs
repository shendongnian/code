    public static class TypeExtensions
    {
        public static List<Type> GetAllDerivedTypes(this Type type)
        {
            return Assembly.GetAssembly(type).GetAllDerivedTypes(type);
        }
        public static List<Type> GetAllDerivedTypes(this Assembly assembly, Type type)
        {
            return assembly
                .GetTypes()
                .Where(t => t != type && type.IsAssignableFrom(t))
                .ToList();
        }
    }
