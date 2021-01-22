    public static object InvokeMethod(this object o, string methodName, params object[] args)
    {
        var type = o.GetType();
        var method = type.GetTypeInfo().GetDeclaredMethod(methodName);
        return method.Invoke(o, args);
    }
