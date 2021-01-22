    public List<string> SplitAddresses(string addresses)
	{
		var result = new List<string>();
		var startIndex = 0;
		var currentIndex = 0;
		var inQuotedString = false;
		while (currentIndex < addresses.Length)
		{
			if (addresses[currentIndex] == QUOTE)
			{
				inQuotedString = !inQuotedString;
			}
			// Split if a comma is found, unless inside a quoted string
			else if (addresses[currentIndex] == COMMA && !inQuotedString)
			{
				var address = GetAndCleanSubstring(addresses, startIndex, currentIndex);
				if (address.Length > 0)
				{
					result.Add(address);
				}
				startIndex = currentIndex + 1;
			}
			currentIndex++;
		}
		if (currentIndex > startIndex)
		{
			var address = GetAndCleanSubstring(addresses, startIndex, currentIndex);
			if (address.Length > 0)
			{
				result.Add(address);
			}
		}
		if (inQuotedString)
			throw new FormatException("Unclosed quote in email addresses");
		return result;
	}
	private string GetAndCleanSubstring(string addresses, int startIndex, int currentIndex)
	{
		var address = addresses.Substring(startIndex, currentIndex - startIndex);
		address = address.Trim();
		return address;
	}
