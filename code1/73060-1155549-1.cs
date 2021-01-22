    public static IEnumerable<FieldInfo> GetAllFields(Type t)
    {
        if (t == null)
            return Enumerable.Empty<FieldInfo>();
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        return t.GetFields(flags).Concat(GetAllFields(t.BaseType));
    }
