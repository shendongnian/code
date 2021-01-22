    public void Wrapper(Action action)
    {
        MethodInfo method = action.Method;
        Type type = method.DeclaringType; // TestClass
        string name = method.Name; // Hello
    }
