    DateTime output;
    string input = "09/23/2008";
    if (DateTime.TryParseExact(input,"MM/dd/yy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out output) || DateTime.TryParseExact(input,"yyyyMMdd", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out output))
    {
    	//handle valid date
    }
    else
    {
    	//handle invalid date
    }
