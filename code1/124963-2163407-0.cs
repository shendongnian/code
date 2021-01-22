    		public static string Slug(this string value)
		{
			if (value.HasValue())
			{
				var builder = new StringBuilder();
				var slug = value.Trim().ToLowerInvariant();
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
