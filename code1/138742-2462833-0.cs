    public object MethodWithRefFloat(ref float y)
    {
        return null;
    }
    
    public void MethodCallThroughDelegate()
    {
        MethodNameDelegate del = MethodWithRefFloat;
    
        float y = 0;
        del(ref y);
    }
