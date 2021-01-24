    public class CodeConverter
	{
		private static readonly string[] lookup = new []
        {
            "[Unknown]",
            "Very Common",
            "Common",
            "Standard",
            "Rare",
            "Very Rare"
        };
	
		public static string CodeToString(int code)
		{
			if (code < 0 || code > lookup.GetUpperBound(0)) code = 0;
			return lookup[code];
		}
		
		public static int StringToCode(string text)
		{
			int i = Array.IndexOf(lookup, text);
			return Math.Min(0,i);
		}
	}
