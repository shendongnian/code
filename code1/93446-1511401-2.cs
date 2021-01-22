    public string amethod(string functionName) 
    {
        Type type = typeof(AVeryLargeWebServiceWithLotsOfMethodsToCall);
        MethodInfo method = type.GetMethod(functionName, BindingFlags.Public | BindingFlags.Static);
        object result = method.Invoke(null,null); // Static methods, with no parameters
        if (result == null)
            return string.Empty;
        return result.ToString();
        // Could also be return (int)result;, if it was an integer (boxed to an object), etc.
    }
