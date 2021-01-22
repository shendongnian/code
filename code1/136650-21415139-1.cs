    #region QQ
    
    [DebuggerStepThrough]
    public static string QQQ(this string str, string value2)
    {
    	return (str != null && str.Length > 0)
    		? str
    		: value2;
    }
    
    [DebuggerStepThrough]
    public static string QQQ(this string str, string value2, string value3)
    {
    	return (str != null && str.Length > 0)
    		? str
    		: (value2 != null && value2.Length > 0)
    			? value2
    			: value3;
    }
    
    
    // Following is only two QQ, just checks null, but allows more than 1 string unlike ?? can do:
    
    [DebuggerStepThrough]
    public static string QQ(this string str, string value2, string value3)
    {
    	return (str != null)
    		? str
    		: (value2 != null)
    			? value2
    			: value3;
    }
    
    #endregion
