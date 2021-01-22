		public static bool FitsMasks(string filePath, params string[] fileMasks)
                // or
		public static Regex FileMasksToRegex(params string[] fileMasks)
		{
			if (!_maskRegexes.ContainsKey(fileMasks))
			{
				StringBuilder sb = new StringBuilder("^");
				bool first = true;
				foreach (string fileMask in fileMasks)
				{
					if(first) first =false; else sb.Append("|");
					sb.Append('(');
					foreach (char c in fileMask)
					{
						switch (c)
						{
							case '*': sb.Append(@".*"); break;
							case '?': sb.Append(@"."); break;
							default:
									sb.Append(Regex.Escape(c.ToString()));
								break;
						}
					}
					sb.Append(')');
				}
				sb.Append("$");
				_maskRegexes[fileMasks] = new Regex(sb.ToString(), RegexOptions.IgnoreCase);
			}
			return _maskRegexes[fileMasks].IsMatch(filePath);
                        // or
			return _maskRegexes[fileMasks];
		}
		static readonly Dictionary<string[], Regex> _maskRegexes = new Dictionary<string[], Regex>(/*unordered string[] comparer*/);
