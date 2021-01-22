    namespace JDanielSmith
    {
    	public static class String
    	{
    		public static bool IsNullOrBlank(string text)
    		{
    			return text == null || text.Trim().Length == 0;
    		}
    	}
    }
