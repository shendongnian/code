	public static class Extensions
	{
		public static string TrimDouble(this string temp)
		{
			var value = temp.IndexOf('.') == -1 ? temp : temp.TrimEnd('.', '0');
			return value == string.Empty ? "0" : value;
		}
	}
