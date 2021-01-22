    public enum FrequencyType
    {
    None = 0,
    Daily = 1,
    Weekly = 2,
    Monthly = 3,
    Quarterly = 4,
    Annually = 5,
    }
    private string[] GetRange(FrequencyType frequency, DateTime dateToCheck)
    {
    string[] result = new string [2];
    DateTime dateRangeBegin = dateToCheck;
    TimeSpan duration = new TimeSpan(0, 0, 0, 0); //One day 
    DateTime dateRangeEnd = DateTime.Today.Add(duration);
    switch (frequency)
	{
        case FrequencyType.Daily:
            dateRangeBegin = dateToCheck;
            dateRangeEnd = dateRangeBegin;
            break;
    
        case FrequencyType.Weekly:
            dateRangeBegin = dateToCheck.AddDays(-(int)dateToCheck.DayOfWeek);
            dateRangeEnd = dateToCheck.AddDays(6 - (int)dateToCheck.DayOfWeek);
            break;
    
        case FrequencyType.Monthly:
            duration = new TimeSpan(DateTime.DaysInMonth ( dateToCheck.Year, dateToCheck.Month) - 1 , 0, 0, 0);
            dateRangeBegin = dateToCheck.AddDays((-1) * dateToCheck.Day + 1);
            dateRangeEnd = dateRangeBegin.Add(duration); 
            break;
    
        case FrequencyType.Quarterly:
            int currentQuater = (dateToCheck.Date.Month - 1) / 3 + 1;
            int daysInLastMonthOfQuarter = DateTime.DaysInMonth(dateToCheck.Year, 3 * currentQuater );
            dateRangeBegin = new DateTime ( dateToCheck.Year, 3 * currentQuater - 2, 1);
            dateRangeEnd = new DateTime(dateToCheck.Year, 3 * currentQuater ,  daysInLastMonthOfQuarter);
            break;
    
        case FrequencyType.Annually:
           dateRangeBegin = new DateTime(dateToCheck.Year, 1, 1);
           dateRangeEnd = new DateTime(dateToCheck.Year, 12, 31); 
           break;
    }
    result[0] = dateRangeBegin.Date.ToString();
    result[1] = dateRangeEnd.Date.ToString();
    return result; 
    }
    
    
