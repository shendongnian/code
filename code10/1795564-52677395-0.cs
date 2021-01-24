    int i = 1;
    while(!CashFlowDatesFinal.Contains(Convert.ToDateTime(a).AddDays(i).ToShortDateString()))
    {
        i++;
    }
    HolidayAdjustedTenorDates.Add(Convert.ToDateTime(a).AddDays(i).ToShortDateString();
