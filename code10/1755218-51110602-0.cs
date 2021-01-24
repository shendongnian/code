	public static DateTime ParseDate(string input)
	{
		DateTime result;
		
		if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out result)) return result;
		if (DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out result)) return result;
		
		throw new FormatException();
	}
