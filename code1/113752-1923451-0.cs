		// named groups are very cool for this...
		public static Regex regex = new Regex("\\|(?:\\s*)(?<key>(\\w+)(\\s*))=(?<value>[^|]+)", RegexOptions.CultureInvariant | RegexOptions.Compiled);
		public static Dictionary<string, string> Extract(string line)
		{
			Dictionary<string, string> results = new Dictionary<string, string>();			
			foreach (Match match in regex.Matches(line))
			{
				var groupKey = match.Groups["key"];
				var groupValue = match.Groups["value"];
				if (groupKey.Success && groupValue.Success)
				{
					// add the group value trimmed as we might have extra blank spaces
					results[groupKey.Value.Trim()] = groupValue.Value.Trim();
				}
			}
			return results;
		}
