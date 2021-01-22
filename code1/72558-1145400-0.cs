    public static class Extensions
	{
		public static string HtmlEncode(this string s)
		{
			return HttpUtility.HtmlEncode(s);
		}
	}
