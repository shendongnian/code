    DateTime startDate = new DateTime(2018, 06, 25); //date time picker's date
    DateTime endDate = new DateTime(2018, 07, 05); //date time picker's date
    Dictionary<int, int> daysInMonth = new Dictionary<int, int>();
    while(true)
    {
        DateTime thisMonthEndDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));
        if (thisMonthEndDate > endDate)
        {
            thisMonthEndDate = endDate;
            daysInMonth.Add(startDate.Month, (int)(thisMonthEndDate - startDate).TotalDays + 1);
            break;
        }
        daysInMonth.Add(startDate.Month, (int)(thisMonthEndDate - startDate).TotalDays + 1);
        startDate = thisMonthEndDate.AddDays(1);
    }
