        		if (eps == enumParseState.StartToken)
				{
					if (rWhiteSpace.IsMatch(c.ToString()))
					{
						//Skip whitespace
					}
					else if (c == '"')
					{
						eps = enumParseState.InQuote;
					}
					else
					{
						token.Append(c);
						eps = enumParseState.InToken;
					}
				}
