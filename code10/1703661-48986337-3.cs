	public DateTime? GetCreationDate(string fileResult)
    {
        int index = fileResult.IndexOf("_");
        if (index <= 0)
			return null;
        // check for string length, you don't want the following call to fileResult.Substring to throw an exception
        if (fileResult.Length < index+20)
            return null;
		string date = fileResult.Substring(index + 1, 20);
		
		DateTime dt;
		if (DateTime.TryParseExact(date, "yyyy_MM_dd__HH_mm_ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
			return dt;
        return null;
    }
