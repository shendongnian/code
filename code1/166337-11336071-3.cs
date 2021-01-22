		//prior to EF 6 [System.Data.Objects.DataClasses.EdmFunction("Your.Namespace", "String_Like")]
		//With EF 6
		[System.Data.Entity.DbFunction("Your.Namespace", "String_Like")]
		public static bool Like(this string input, string pattern)
		{
			/* Turn "off" all regular expression related syntax in
			 * the pattern string. */
			pattern = Regex.Escape(pattern);
			/* Replace the SQL LIKE wildcard metacharacters with the
			 * equivalent regular expression metacharacters. */
			pattern = pattern.Replace("%", ".*?").Replace("_", ".");
			/* The previous call to Regex.Escape actually turned off
			 * too many metacharacters, i.e. those which are recognized by
			 * both the regular expression engine and the SQL LIKE
			 * statement ([...] and [^...]). Those metacharacters have
			 * to be manually unescaped here. */
			pattern = pattern.Replace(@"\[", "[").Replace(@"\]", "]").Replace(@"\^", "^");
			return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
		}
