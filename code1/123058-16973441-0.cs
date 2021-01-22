    public static bool IsCastableTo(this Type from, Type to)
    {
        return to.IsAssignableFrom(from)
            || to.GetConvertOperators().Any(m => m.GetParameters()[0].ParameterType.IsAssignableFrom(from))
            || from.GetConvertOperators(true).Any(m => to.IsAssignableFrom(m.ReturnType));
    }
    public static IEnumerable<MethodInfo> GetConvertOperators(this Type type, bool lookInBase = false)
    {
        var bindinFlags = BindingFlags.Public
                        | BindingFlags.Static
                        | (lookInBase ? BindingFlags.FlattenHierarchy : BindingFlags.DeclaredOnly);
        return type.GetMethods(bindinFlags).Where(m => (m.Name == "op_Implicit" || m.Name == "op_Explicit"));
    }
