    public static bool IsGenericList(this object o)
    {
    	var oType = o.GetType();
    	return (oType.IsGenericType && (oType.GetGenericTypeDefinition() == typeof(List<>)));
    }
