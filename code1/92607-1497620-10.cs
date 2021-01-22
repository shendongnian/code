    var datesAndISO8601Weeks = new Dictionary<DateTime, int>
    				        {
    					        {new DateTime(2000, 12, 31), 52},
    					        {new DateTime(2001, 1, 1), 1},
    					        {new DateTime(2005, 1, 1), 53},
    					        {new DateTime(2007, 12, 31), 1},
    					        {new DateTime(2008, 12, 29), 1},
    					        {new DateTime(2010, 1, 3), 53},
    					        {new DateTime(2011, 12, 31), 52},
    					        {new DateTime(2012, 1, 1), 52},
    					        {new DateTime(2013, 1, 2), 1},
    					        {new DateTime(2013, 12, 31), 1},
    				        };
    
    foreach (var dateWeek in datesAndISO8601Weeks)
    {
    	Debug.Assert(WeekOfYearISO8601(dateWeek.Key) == dateWeek.Value, dateWeek.Key.ToShortDateString() + " should be week number " + dateWeek.Value + " but was " + WeekOfYearISO8601(dateWeek.Key));
    }
