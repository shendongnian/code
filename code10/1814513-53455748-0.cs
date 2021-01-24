    public static class Extensions
    {
    	public static string Reverse(this string s)
    	{
    		var charArray = s.ToCharArray();
    		Array.Reverse(charArray);
    		return new string (charArray);
    	}
    }
