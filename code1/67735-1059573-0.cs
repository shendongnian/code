    DateTime parsedDate;
    if (DateTime.TryParseExact("0111", "MMdd", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
    {
    	// do something with parsedDate.Month and parsedDate.Day
    }
