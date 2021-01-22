    static IEnumerable<Type> GetNestedDelegates(Type type)
    {
        return type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic)
                   .Where(t => t.BaseType == typeof(MulticastDelegate));
    }
