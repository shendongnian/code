    public static class StringExtensions
    {
    	public static string Reverse(this string input)
    	{
    		return string.Concat(Enumerable.Reverse(input));
    	}
    }
