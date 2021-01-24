    public static string RemoveDiacritics(Dictionary<char, char[]> exclude, string source)
	{
		string exclusionGroup = string.Join("|", exclude.Select(p => string.Concat(p.Key, string.Join(string.Empty, p.Value))));
		string leaveOnly = String.Concat(String.Format(@"({0})|\p{{M}}+", exclusionGroup));
		return Regex.Replace(source, leaveOnly, "$1");
	}
