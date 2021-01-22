    public static bool IsCastableTo(this Type from, Type to)
    {
        return to.IsAssignableFrom(from)
            || IsCastDefined(to, m => m.GetParameters()[0].ParameterType, _ => from, false)
            || IsCastDefined(from, _ => to, m => m.ReturnType, true);
    }
    //little irrelevant dry method
    static bool IsCastDefined(Type type, Func<MethodInfo, Type> baseType, Func<MethodInfo, Type> derivedType, 
                              bool lookInBase)
    {
        var bindinFlags = BindingFlags.Public
                        | BindingFlags.Static
                        | (lookInBase ? BindingFlags.FlattenHierarchy : BindingFlags.DeclaredOnly);
        return type.GetMethods(bindinFlags).Any(m => (m.Name == "op_Implicit" || m.Name == "op_Explicit") 
                                                  && baseType(m).IsAssignableFrom(derivedType(m)));
    }
