    public static bool DatesAreWithinOneYear(DateTime date1, DateTime date2)
    {
        DateTime startDate, endDate;
        if (date1 > date2)
        {
            startDate = date2; endDate = date1;
        }
        else
        {
            startDate = date1; endDate = date2;
        }
        int years = endDate.Year - startDate.Year;
        if (endDate < startDate.AddYears(years))
        {
            years--;
        }
        return years < 1;
    }
