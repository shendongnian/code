	public static class StringExtensions
	{
		public static string TruncateTo(this string val, int maxLength, bool ellipsis = true)
		{
			if (val == null || val.Length <= maxLength)
			{
				return val;
			}
			ellipsis = ellipsis && maxLength >= 3;
			return ellipsis ? val.Substring(0, maxLength - 3) + "..." : val.Substring(0, maxLength);
		}
	}
