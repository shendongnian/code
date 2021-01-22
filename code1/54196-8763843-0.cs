    namespace ExtensionMethods
    {
    	public static class TimeSpanExtensionMethods
    	{
    		public static string ToReadableString(this TimeSpan span)
    		{
    			string formatted = string.Format("{0}{1}{2}",
    				(span.Days / 7) > 0 ? string.Format("{0:0} weeks, ", span.Days / 7) : string.Empty,
    				span.Days % 7 > 0 ? string.Format("{0:0} days, ", span.Days % 7) : string.Empty,
    				span.Hours > 0 ? string.Format("{0:0} hours, ", span.Hours) : string.Empty);
    
    			if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);
    
    			return formatted;
    		}
    	}
    }
