	static IEnumerable<string> CsvParse(string input)
	{
		// null strings return a one-element enumeration containing null.
		if (input == null)
		{
			yield return null;
			yield break;
		}
	
		// we will 'eat' bits of the string until it's gone.
		String remaining = input;
		while (remaining.Length > 0)
		{
	
			if (remaining.StartsWith("\"")) // deal with quotes
			{
				remaining = remaining.Substring(1); // pass over the initial quote.
	
				// find the end quote.
				int endQuotePosition = remaining.IndexOf("\"");
				switch (endQuotePosition)
				{
					case -1:
						// unclosed quote.
						throw new ArgumentOutOfRangeException("Unclosed quote");
					case 0:
						// the empty quote
						yield return "";
						remaining = remaining.Substring(2);
						break;
					default:
						string quote = remaining.Substring(0, endQuotePosition).Trim();
						remaining = remaining.Substring(endQuotePosition + 1);
						yield return quote;
						break;
				}
			}
			else // deal with commas
			{
				int nextComma = remaining.IndexOf(",");
				switch (nextComma)
				{
					case -1:
						// no more commas -- read to end
						yield return remaining.Trim();
						yield break;
	
					case 0:
						// the empty cell
						yield return "";
						remaining = remaining.Substring(1);
						break;
	
					default:
						// get everything until next comma
						string cell = remaining.Substring(0, nextComma).Trim();
						remaining = remaining.Substring(nextComma + 1);
						yield return cell;
						break;
				}
			}
		}
	
	}
