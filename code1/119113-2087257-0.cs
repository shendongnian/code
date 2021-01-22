    foreach (string Token in tokenize(Command))
	{
	foreach (KeyValuePair<string, string> Replacement in TokensToReplace)
		{
		if (Token==Replacement.Key)
			{
			Token = Replacement.Value;
			}
		}
	TokenList.Add(Token);
	}
