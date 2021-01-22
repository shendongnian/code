		public static string Escape(this string text, string controlChars, char escapeCharacter)
		{
			var builder = new StringBuilder(text.Length + 3);
			foreach (var ch in text)
			{
				if (controlChars.Contains(ch))
				{
					builder.Append(escapeCharacter);
				}
				builder.Append(ch);
			}
			return builder.ToString();
		}
		public static string Unescape(string text, char escapeCharacter)
		{
			var builder = new StringBuilder(text.Length);
			bool escaped = false;
			foreach (var ch in text)
			{
				escaped = escapeCharacter == ch && !escaped;
				if (!escaped)
				{
					builder.Append(ch);
				}
			}
			return builder.ToString();
		}
