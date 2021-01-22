		public static string StripTags(string value)
		{
			if (value == null)
				return string.Empty;
			string pattern = @"&.{1,8};";
			value = Regex.Replace(value, pattern, " ");
			pattern = @"<(.|\n)*?>";
			return Regex.Replace(value, pattern, string.Empty);
		}
