	public static DateTime? CustomParse(string dateString)
	{
		DateTime date;
		
        //Hard code the 'a' in the parse string
		if(DateTime.TryParseExact(dateString, "h:mma ET MM/dd/yy", new CultureInfo("en-US"), DateTimeStyles.None, out date))
		{
			return date;
		}
        //'a' wasnt in the right position, try the 'p'
		else if(DateTime.TryParseExact(dateString, "h:mmp ET MM/dd/yy", new CultureInfo("en-US"), DateTimeStyles.None, out date))
		{
            //Adding 12 hours to make it "PM" to the DateTime object
			date = date.AddHours(12);
			return date;
		}				
		
        // Could not parse, return null
		return null;
	}
