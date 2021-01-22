    public static class StringExtensions
    {
    
    	public static string SubstringBetweenIndexes(string value, int startIndex, int endIndex)
    	{
    		return value.Substring(startIndex, endIndex - startIndex);
    	}
    
    }
