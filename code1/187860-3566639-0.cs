	public static class StringExtensions
	{
		public static string NextLine(this string s, string next)
		{
			return s + Environment.NewLine + next;
		}
		public static string NextLine(this string s)
		{
            // just add a new line with no text
			return s + Environment.NewLine;
		}
	}
