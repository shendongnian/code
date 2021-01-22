    [ThreadStatic]
    private static Dictionary<string, string> _MyProperty;
    public static Dictionary<string, string> MyProperty 
    {
        get
        {
            return _MyProperty = _MyProperty ?? StaticFunctionToLoadValues();
        }
    }
