    public object MethodWithRefFloat(ref float y)
    {
        return null;
    }
    
    public void MethodCallThroughDelegate()
    {
        MethodNameDelegate myDelegate = MethodWithRefFloat;
    
        float y = 0;
        myDelegate(ref y);
    }
