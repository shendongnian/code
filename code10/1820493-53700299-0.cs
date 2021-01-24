    public static class ReflectionHelper
    {
    	public static Object GetPropValue(this Object obj, String propName)
    	{
    		string[] nameParts = propName.Split('.');
    		if (nameParts.Length == 1)
    		{
    			return obj.GetType().GetProperty(propName).GetValue(obj, null);
    		}
    
    		foreach (String part in nameParts)
    		{
    			if (obj == null) { return null; }
    
    			Type type = obj.GetType();
    			PropertyInfo info = type.GetProperty(part);
    			if (info == null) { return null; }
    
    			obj = info.GetValue(obj, null);
    		}
    		return obj;
    	}
    }
