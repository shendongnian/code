    public static class MyExtensions
    {
    	public static int GetPropC(this MyObjectType obj, int dfltVal)
    	{
    		if (obj != null && obj.PropertyA != null & obj.PropertyB != null)
    			return obj.PropertyC;
    		return dfltVal;
    	}
    }
