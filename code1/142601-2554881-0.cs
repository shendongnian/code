    public static bool IsBirthDayInRange(DateTime birthday, DateTime start, DateTime end)
    {
        DateTime temp = new DateTime(start.Year, birthday.Month, birthday.Day);
        if (temp < start)
            temp = temp.AddYears(1);
        return temp >= start && temp <= end;
    }
