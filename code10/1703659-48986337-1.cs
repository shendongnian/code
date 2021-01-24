	public static DateTime? GetCreationDate(string fileResult)
    {
        int index = fileResult.IndexOf("_");
        if (index <= -1)
			return null;
		string date = fileResult.Substring(index + 1, 20);
		Console.WriteLine(date);
		
		DateTime dt;
		if (DateTime.TryParseExact(date, "yyyy_MM_dd__HH_mm_ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
			return dt;
        return null;
    }
