    static Type GenerateFuncOrAction(MethodInfo method)
    {
        var typeParams = method.GetParameters().Select(p => p.ParameterType).ToArray();
        if (method.ReturnType == typeof(void))
        {
            if (typeParams.Length == 0)
            {
                return typeof(Action);
            }
            else if (typeParams.Length == 1)
            {
                return typeof(Action<>).MakeGenericType(typeParams);
            }
            else if (typeParams.Length == 2)
            {
                return typeof(Action<,>).MakeGenericType(typeParams);
            }
            else if (typeParams.Length == 3)
            {
                return typeof(Action<,,>).MakeGenericType(typeParams);
            }
            throw new ArgumentException("Only written up to 3 type parameters");
        }
        else
        {
            if (typeParams.Length == 0)
            {
                return typeof(Func<>).MakeGenericType(typeParams.Concat(new[] { method.ReturnType }).ToArray());
            }
            else if (typeParams.Length == 1)
            {
                return typeof(Func<,>).MakeGenericType(typeParams.Concat(new[] { method.ReturnType }).ToArray());
            }
            else if (typeParams.Length == 2)
            {
                return typeof(Func<,,>).MakeGenericType(typeParams.Concat(new[] { method.ReturnType }).ToArray());
            }
            else if (typeParams.Length == 3)
            {
                return typeof(Func<,,,>).MakeGenericType(typeParams.Concat(new[] { method.ReturnType }).ToArray());
            }
            throw new ArgumentException("Only written up to 3 type parameters");
        }
    }
