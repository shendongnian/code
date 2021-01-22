    [ThreadStatic]
    private static Dictionary<string, string> _MyProperty;
    public static Dictionary<string, string> MyProperty 
    {
        get
        {
            if (null == _MyProperty)
            {
                _MyProperty = StaticFunctionToLoadValues();
            }
            return _MyProperty;
        }
    }
