    void Main()
    {
        ("January".GetMonthIndex() > "May".GetMonthIndex()).Dump();
		("January".GetMonthIndex() == "january".GetMonthIndex()).Dump();
		("January".GetMonthIndex() < "May".GetMonthIndex()).Dump();
    }
    public static class Extension {
	    public static int GetMonthIndex(this string month) {
		    return Array.FindIndex( CultureInfo.CurrentCulture.DateTimeFormat.MonthNames,
	                         t => t.Equals(month, StringComparison.CurrentCultureIgnoreCase));
	    }
    }
