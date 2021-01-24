	private static string ToPascalCase(string input)
	{
		if(input == null)
		{
			throw new ArgumentNullException("input");
		}
		
		TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
		
		var sb = new StringBuilder();
		foreach(var part in input.Split('_'))
		{
			sb.Append(textInfo.ToTitleCase(part.ToLower()));
		}
		
		return sb.ToString();
	}
