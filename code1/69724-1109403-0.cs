    DateTime startDate = ...somedate;
    DateTime endDate = ...somedate;
    myTableAdapter.SelectCommand.Text = GetExpiringMembershipsSql(startDate, EndDate);
    
    ...
    
    public static void GetExpiringMembershipsSql(DateTime startDate, DateTime endDate)
    {
    	string template = @"SELECT   [Last Name], [First Name], [Renewal Date]
    FROM     Members
    WHERE    ([Renewal Date] >= #{0}#) AND ([Renewal Date] <= #{1}#)
    ORDER BY [Renewal Date]";
    
    	return string.Format(template, startDate.ToShortDateString(), endDate.ToShortDateString());
    }
