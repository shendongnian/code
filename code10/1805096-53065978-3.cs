    public static class ExtensionLib {
    	public static string GetClassName(this Type objType)
    	{
    
    		string result = objType.Name;
    		if (objType.IsGenericType)
    		{
    			var name = objType.Name.Substring(0, objType.Name.IndexOf('`'));
    			var genericTypes = objType.GenericTypeArguments;
    			result = $"{name}<{string.Join(",", genericTypes.Select(x=> x.IsGenericType ? x.GetClassName() : x.Name))}>";
    		}
    		return result;
    	}
    }
