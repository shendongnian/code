    public static class Extensions
    {
         public static string RemoveComma(this string value)
         {
             if (value == null) throw new ArgumentNullException("value");
        	return value.Replace(",", "");
        }
    }  
