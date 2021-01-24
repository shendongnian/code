    public static class Extensions
    {
    	public static long MsTicks(this int i)
    	{
    		return TimeSpan.FromMilliseconds(i).Ticks;
    	}
    }
