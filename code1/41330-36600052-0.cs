    public string GetNamespace(object obj)
    {
        var nameSpace = obj.GetType().Namespace;//Get the namespace
    
        return nameSpace;
    }
