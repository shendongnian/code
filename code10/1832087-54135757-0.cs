    public static bool ContainsRegex(string haystack, string startsWith, string contains) 
	{
		var delims = contains.Select(x => x.ToString().Replace("\\", @"\\").Replace("-", @"\-").Replace("^", @"\^").Replace("]", @"\]")).ToList();
		var pat = $@"^{startsWith} \w+{Regex.Escape(contains.Substring(0,1))}[^{string.Concat(delims)}]*{Regex.Escape(contains.Substring(1,1))}[^{delims[0]}{delims[2]}]*{Regex.Escape(contains.Substring(2,1))}";
		// Console.WriteLine(pat); // => ^NOT \w+\{[^{,}]*,[^{}]*}
		return Regex.IsMatch(haystack, pat, RegexOptions.IgnoreCase);
	}
