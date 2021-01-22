	private static Regex hrefRegex = new Regex("<td>\\s*<a\\s*href\\s*=\\s*(?:\"(?<link>[^\"]*)\"|(?<link>\\S+))\\s*>(?<name>.*)\\s*</a>\\s*</td>",  RegexOptions.IgnoreCase | RegexOptions.Compiled);
	
	public static bool TryGetHrefDetails(string htmlTd, out string link, out string name)
	{
		var matches = hrefRegex.Match(htmlTd);
		if (matches.Success)
		{
			link = matches.Result("${link}");
			name = matches.Result("${name}");
			return true;
		}
		else
		{
			link = null;
			name = null;
			return false;
		}
	}
