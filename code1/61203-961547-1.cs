	public static class StringExtension
	{
		public static bool HasValue(this string value)
		{
			return string.IsNullOrEmpty(value) == false;
		}
		public static string Slug(this string value)
		{
			if (value.HasValue())
			{
				var builder = new StringBuilder();
				var slug = value.Trim().ToLower();
				foreach (var c in slug)
				{
					switch (c)
					{
						case ' ':
							builder.Append("-");
							break;
						case '&':
							builder.Append("and");
							break;
						default:
							if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') && c != '-')
							{
								builder.Append(c);
							}
							break;
					}
				}
				return builder.ToString();
			}
			return string.Empty;
		}
		public static string Truncate(this string value, int limit)
		{
			return (value.Length > limit) ? string.Concat(value.Substring(0, Math.Min(value.Length, limit)), "...") : value;
		}
	}
