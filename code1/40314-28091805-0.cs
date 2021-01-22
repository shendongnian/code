		public static IEnumerable<string> Split(
			this string text, 
			char separator, 
			char escapeCharacter)
		{
			var builder = new StringBuilder(text.Length);
			bool escaped = false;
			foreach (var ch in text)
			{
				if (separator == ch && !escaped)
				{
					yield return builder.ToString();
					builder.Clear();
				}
				else
				{
					// separator is removed, escape characters are kept
					builder.Append(ch);
				}
				// set escaped for next cycle, 
				// or reset unless escape character is escaped.
				escaped = escapeCharacter == ch && !escaped;
			}
			yield return builder.ToString();
		}
