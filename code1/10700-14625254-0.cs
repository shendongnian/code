    public static Type GetType(string fullName)
    {
    	if (string.IsNullOrEmpty(fullName))
    		return null;
    	Type type = Type.GetType(fullName);
    	if (type == null)
    	{
    		string targetAssembly = fullName;
    		while (type == null && targetAssembly.Length > 0)
    		{
    			try
    			{
    				int dotInd = targetAssembly.LastIndexOf('.');
    				targetAssembly = dotInd >= 0 ? targetAssembly.Substring(0, dotInd) : "";
    				if (targetAssembly.Length > 0)
    					type = Type.GetType(fullName + ", " + targetAssembly);
    			}
    			catch { }
    		}
    	}
    	return type;
    }
