		public static bool FitsMask(string filePath, string fileMask)
		{
			if (!_maskRegexes.ContainsKey(fileMask))
			{
				StringBuilder sb = new StringBuilder();
				foreach (char c in fileMask)
				{
					switch (c)
					{
						case '.': sb.Append(@"\."); break;
						case '*': sb.Append(@".*"); break;
						case '?': sb.Append(@"."); break;
						default:
							sb.Append(Regex.Escape(c.ToString()));
							break;
					}
				}
				sb.Append("$");
				_maskRegexes[fileMask] = new Regex(sb.ToString(), RegexOptions.IgnoreCase);
			}
			return _maskRegexes[fileMask].IsMatch(filePath);
		}
		static readonly Dictionary<string, Regex> _maskRegexes = new Dictionary<string, Regex>();
