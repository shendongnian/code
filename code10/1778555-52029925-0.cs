    public static class Ext {
    	public static bool IsOverloads(this Type type,string methodName)
    	{
    		var info = type.GetMethods();
    		return info.Where(o1 => o1.Name == methodName).Count() > 1;
    	}
    }
