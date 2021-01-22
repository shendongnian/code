    using System;
    using System.Text.RegularExpressions;
    
    public static class StringHelpers
    {
        public static string StripHTML(this string HTMLText)
    		{
    			var reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
    			return reg.Replace(HTMLText, "");
    		}
    }
