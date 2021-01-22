    static MethodInfo GetMethod(Type argType, Type returnType)
    {
        var methods = from m in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                      where m.ContainsGenericParameters
                      && m.Name == "Average"
                      && m.GetParameters()[1].ParameterType.GetGenericTypeDefinition() == typeof(Func<,>)
                      && m.GetParameters()[1].ParameterType.GetGenericArguments()[1] == returnType
                      select m;
        return methods.First();
    }
