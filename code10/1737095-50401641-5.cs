    public static class TickExtensions
    {
    	public static long Ms(this int ms)
    	{
    		return TimeSpan.FromMilliseconds(ms).Ticks;
    	}
    }
