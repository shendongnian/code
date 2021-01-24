	string dateString = "9:53p ET 08/13/18";
	DateTime date;
	
    //Hard code the 'a' in the parse string
	if(DateTime.TryParseExact(dateString, "h:mma ET MM/dd/yy", new CultureInfo("en-US"), DateTimeStyles.None, out date))
	{
		Console.WriteLine(date);
	}
    //'a' wasnt in the right position, try the 'p'
	else if(DateTime.TryParseExact(dateString, "h:mmp ET MM/dd/yy", new CultureInfo("en-US"), DateTimeStyles.None, out date))
	{
        //Adding 12 hours to make it "PM"
		date = date.AddHours(12);
		Console.WriteLine(date);
	}
