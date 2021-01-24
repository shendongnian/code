    // Output:
    // Weeks between 12/28/2017 and 1/10/2018: 2
    // Weeks between 4/13/2018 and 4/16/2018: 1
    // Weeks between 4/21/2018 and 4/22/2018: 0
    // Weeks between 4/22/2018 and 4/23/2018: 1
    void Main()
    {
    	var datePairs = new List<KeyValuePair<DateTime, DateTime>>();
    	datePairs.Add(new KeyValuePair<DateTime, DateTime>(new DateTime(2017, 12, 28), new DateTime(2018, 1, 10)));
    	datePairs.Add(new KeyValuePair<DateTime, DateTime>(new DateTime(2018, 4, 13), new DateTime(2018, 4, 16)));
    	datePairs.Add(new KeyValuePair<DateTime, DateTime>(new DateTime(2018, 4, 21), new DateTime(2018, 4, 22)));
    	datePairs.Add(new KeyValuePair<DateTime, DateTime>(new DateTime(2018, 4, 22), new DateTime(2018, 4, 23)));
    	
    	foreach (var datePair in datePairs)
    	{
    		var string1 = datePair.Key.ToShortDateString();
    		var string2 = datePair.Value.ToShortDateString();
    		Console.WriteLine($"Weeks between {string1} and {string2}: {GetWeekDiff(datePair.Key, datePair.Value)}");
    	}
    }
    
    public static int GetWeekDiff(DateTime dtStart, DateTime dtEnd)
    {
    	var totalDays = (dtEnd - dtStart).TotalDays;
    	var weeks = (int)totalDays / 7;
    	var hasRemainder = totalDays % 7 > 0;
    	if (hasRemainder)
    	{
    		if (!(dtStart.DayOfWeek.Equals(DayOfWeek.Saturday) && dtEnd.DayOfWeek.Equals(DayOfWeek.Sunday)))
    		{
    			weeks++;
    		}
    	}
    	return weeks;
    }
