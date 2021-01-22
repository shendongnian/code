	public static class StringExtension
	{
		private static readonly Dictionary<string, string> Replacements = new Dictionary<string, string>() { { "&", "and" }, { ",", "" }, { " ", " " } /* etc */ };
		/// LINQ Equivalent return Replacements.Keys.Aggregate(s, (current, toReplace) => current.Replace(toReplace, Replacements[toReplace]));
		public static string Clean(this string s)
		{
			foreach (string toReplace in Replacements.Keys)
			{
				s = s.Replace(toReplace, Replacements[toReplace]);
			}
			return s;
		}
	}
