    private static string DecodeQuotedPrintables(string input, string charSet)
	{			
		if (string.IsNullOrEmpty(charSet))
		{
			var charSetOccurences = new Regex(@"=\?.*\?Q\?", RegexOptions.IgnoreCase);
			var charSetMatches = charSetOccurences.Matches(input);
			foreach (Match match in charSetMatches)
			{
				charSet = match.Groups[0].Value.Replace("=?", "").Replace("?Q?", "");
				input = input.Replace(match.Groups[0].Value, "").Replace("?=", "");
			}
		}
		Encoding enc = new ASCIIEncoding();
		if (!string.IsNullOrEmpty(charSet))
		{
			try
			{
				enc = Encoding.GetEncoding(charSet);
			}
			catch
			{
				enc = new ASCIIEncoding();
			}
		}
		//decode iso-8859-[0-9]
		var occurences = new Regex(@"=[0-9A-Z]{2}", RegexOptions.Multiline);
		var matches = occurences.Matches(input);
		foreach (Match match in matches)
		{
			try
			{
				byte[] b = new byte[] { byte.Parse(match.Groups[0].Value.Substring(1), System.Globalization.NumberStyles.AllowHexSpecifier) };
				char[] hexChar = enc.GetChars(b);
				input = input.Replace(match.Groups[0].Value, hexChar[0].ToString());
			}
			catch { }
		}
		//decode base64String (utf-8?B?)
		occurences = new Regex(@"\?utf-8\?B\?.*\?", RegexOptions.IgnoreCase);
		matches = occurences.Matches(input);
		foreach (Match match in matches)
		{
			byte[] b = Convert.FromBase64String(match.Groups[0].Value.Replace("?utf-8?B?", "").Replace("?UTF-8?B?", "").Replace("?", ""));
			string temp = Encoding.UTF8.GetString(b);
			input = input.Replace(match.Groups[0].Value, temp);
		}
		input = input.Replace("=\r\n", "");
		return input;
	}
