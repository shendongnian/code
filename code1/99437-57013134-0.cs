    public static string GetDayName(this DateTime date)
    {
    	string _ret = string.Empty; //Only for .NET Framework 4++
    	var culture = new System.Globalization.CultureInfo("es-419"); //<- 'es-419' = Spanish (Latin America), 'en-US' = English (United States)
    	_ret = culture.DateTimeFormat.GetDayName(date.DayOfWeek); //<- Get the Name 	
    	_ret = culture.TextInfo.ToTitleCase(_ret.ToLower()); //<- Convert to Capital title
    	return _ret;
    }
