    public static class Extensions
    {
    	public static bool In<T>(this T testValue, params T[] values)
    	{
    		return values.Contains(testValue);
    	}
    }
