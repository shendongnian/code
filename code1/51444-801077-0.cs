    // All error checking omitted. In particular, check the results
    // of Type.GetType, and make sure you call it with a fully qualified
    // type name, including the assembly if it's not in mscorlib or
    // the current assembly. The method has to be a public instance
    // method with no parameters. (Use BindingFlags with GetMethod
    // to change this.)
    public void Invoke(string typeName, string methodName)
    {
        Type type = Type.GetType(type);
        object instance = Activator.CreateInstance(type);
        MethodInfo method = type.GetMethod(methodName);
        method.Invoke(instance, null);
    }
