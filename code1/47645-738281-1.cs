        Type t = typeof (X);
        var mi = t.GetMethod("Method");
        var parameters = mi.GetParameters();
        foreach(Type parameterType in parameters.Select(pi => pi.ParameterType))
                Console.WriteLine(parameterType.IsByRef ? parameterType.GetElementType() : parameterType);
