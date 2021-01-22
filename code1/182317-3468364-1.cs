    public static class MyExtensions
    {
    	public static int GetPropC(this MyObjectType obj, int dfltVal)
    	{
    		if (obj != null && obj.PropertyA != null & obj.PropertyA.PropertyB != null)
    			return obj.PropertyA.PropertyB.PropertyC;
    		return dfltVal;
    	}
    }
