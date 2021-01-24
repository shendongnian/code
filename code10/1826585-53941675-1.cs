    public static Type GetType(string typeName)
    {
    	string clrType = null;
    
    	if (CLRConstants.TryGetValue(typeName, out clrType))
    	{
    		return Type.GetType(clrType);
    	}
    
    	var type = Type.GetType(typeName);
    
    	if (type != null) return type;
    	foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
    	{
    		type = a.GetType(typeName);
    		if (type != null)
    			return type;
    	}
    	return null;
    }
    private static Dictionary<string, string> CLRConstants { 
    	get{
    			var dct =  new Dictionary<string, string>();
    			dct.Add("int", "System.Int32");
    			dct.Add("List<int>", "System.Collections.Generic.List`1[System.Int32]");
    			return dct;
    	} 
    }
