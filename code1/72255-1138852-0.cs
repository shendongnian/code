    DateTime dtNow = DateTime.Now;
    DateTime dtYesterday = DateTime.Now.AddDays(-435.0);
    TimeSpan ts = dtNow.Subtract(dtYesterday);
    
    int years = ts.Days / 365; //no leap year accounting
    int months = (ts.Days % 365) / 30; //naive guess at month size
    int weeks = ((ts.Days % 365) % 30) / 7;
    int days = (((ts.Days % 365) % 30) % 7);
    
    StringBuilder sb = new StringBuilder();
    if(years > 0)
    {
    	sb.Append(years.ToString() + " years, ");
    }
    if(months > 0)
    {
    	sb.Append(months.ToString() + " months, ");
    }
    if(weeks > 0)
    {
    	sb.Append(years.ToString() + " weeks, ");
    }
    if(days > 0)
    {
    	sb.Append(years.ToString() + " days.");
    }
    string FormattedTimeSpan = sb.ToString();
