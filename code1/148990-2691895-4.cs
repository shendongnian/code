    StringBuilder sb = new StringBuilder();
    
    DateTime startDate = new DateTime(2010, 1, 1);
    DateTime endDate = new DateTime(2012, 12, 31);
    
    int monthCount =
    	(endDate.Month - startDate.Month + 1) +
    	(endDate.Year - startDate.Year) * 12;
    
    for (int i = 0; i < monthCount; i++)
    {
        DateTime d1 = new DateTime(startDate.Year, startDate.Month, 1).AddMonths(i);
    	string month = d1.ToString("MMMM");
    
    	sb.AppendFormat("<p>{0}</p>", month);
    
    	int daysInMonth = d1.AddMonths(1).AddDays(-1).Day;
    	StringBuilder daysOfWeekRow = new StringBuilder();
    	StringBuilder daysRow = new StringBuilder();
    	for (int j = 0; j < daysInMonth; j++)
    	{
    		DateTime d2 = d1.AddDays(j);
    		string dayOfWeek = d2.ToString("ddd");
    		string day = d2.Day.ToString();
    
    		daysOfWeekRow.AppendFormat("<td>{0}</td>", dayOfWeek);
    		daysRow.AppendFormat("<td>{0}</td>", day);
    	}
    	sb.AppendFormat(
    		"<table><tr>{0}</tr><tr>{1}</tr></table>",
    		daysOfWeekRow.ToString(), 
    		daysRow.ToString()
    	);
    }
    
    string result = sb.ToString();
