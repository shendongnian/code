    public void MyFunctionMethodGroup(string methodName, Type type, object caller)
    {
        var methods = type.GetMethods().Where(x => x.Name == methodName);
        foreach(var method in methods)
        {
            Delegate myDelegate = method.CreateDelegate(Expression.GetDelegateType(
                method.GetParameters().Select(x => x.ParameterType)
                .Concat(new[] { method.ReturnType })
                .ToArray()), method.IsStatic ? null : caller);
            MyFunction(myDelegate);
        }
    }
