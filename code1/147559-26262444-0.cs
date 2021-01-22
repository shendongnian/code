    static object GetObject() { return null; }
    static void SetObject(object obj) { }
    
    static string GetString() { return ""; }
    static void SetString(string str) { }
    
    static void Test()
    {
        // Covariance. A delegate specifies a return type as object, 
        // but you can assign a method that returns a string.
        Func<object> del = GetString;
    
        // Contravariance. A delegate specifies a parameter type as string, 
        // but you can assign a method that takes an object.
        Action<string> del2 = SetObject;
    }
