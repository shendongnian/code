    public static bool IsGenericList(object o)
    {
    	bool isGenericList = false;
    
    	var oType = o.GetType();
    
    	if (oType.IsGenericType && (oType.GetGenericTypeDefinition() == typeof(List<>)))
    		isGenericList = true;
    
    	return isGenericList;
    }
