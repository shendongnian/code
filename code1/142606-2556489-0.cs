    public static bool IsBirthdayInRange(DateTime birthday, DateTime from, DateTime to)
    {
        if (to < from)
        {
            throw new ArgumentException("The specified range is not valid");
        }
        
        int year = from.Year;
        int month = birthday.Month;
        int day = birthday.Day;
        if (from.DayOfYear > to.DayOfYear && birthday.DayOfYear < from.DayOfYear)
        {
            year++;
        }
        if (month == 2 && day == 29 && !DateTime.IsLeapYear(year))
        {
           // Assuming people born on February 29 celebrate their birthday
           // one day earlier on non-leap years
           day--;
        }
        DateTime bDate = new DateTime(year, month, day);
        return bDate >= from.Date && bDate <= to.Date;
    }
