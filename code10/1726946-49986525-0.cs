	public static string ToDateTimeFormat(string input)
	{
		DateTime output;
		if(DateTime.TryParse(input, out output))
		{
			return output.ToString("MMddyy");
		}
		return input; //parse fails, return original input
	}
