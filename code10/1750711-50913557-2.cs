	public static bool TryChangeDateTimeFormat(string inputDateString, string outputFormat, out string outputDateString)
	{
		DateTime parsedDateTime;
		if(DateTime.TryParse(inputDateString, out parsedDateTime))
		{
			outputDateString = parsedDateTime.ToString(outputFormat);
			return true;
		}
		outputDateString = string.Empty;
		return false;
	}
