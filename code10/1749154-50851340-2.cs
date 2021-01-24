    public static class MyExtensions
    {
    	public static string RemoveFirstChar(this string str)
    	{
    	    return	string.IsNullOrEmpty(str) ? str : string.Join("", str.Skip(1));
    	}
        //Or in c#6 and above use expression bodied functions
        /*
        public static string RemoveFirstChar(this string str) => 
            string.IsNullOrEmpty(str) ? str : string.Join("", str.Skip(1));
        */
    }
