	private IList<string> FindEmailAddresses(string body)
	{
		IList<string> emailAddresses = new List<string>;
		string emailMatch = @"\b([A-Z0-9._%-]+)@([A-Z0-9.-]+\.[A-Z]{2,6})\b";
		Regex mailReg = new Regex(emailMatch,
			RegexOptions.IgnoreCase | RegexOptions.Multiline);
		MatchCollection matches = mailReg.Matches(body);
		for (int index = 0; index < matches.Count; index++)
		{
			emailAddresses.Add(matches[index].ToString());
		}
		return emailAddresses;
	}
