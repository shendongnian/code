    public static int RowsForMonth(int month, int year)
    {
        DateTime first = new DateTime(year, month, 1);
        //number of days pushed beyond monday this one sits
        int offset = ((int)first.DayOfWeek) - 1;
        int actualdays = DateTime.DaysInMonth(month, year) +  offset;
        decimal rows = (actualdays / 7);
        if ((rows - ((int)rows)) > .1)
        {
            rows++;
        }
        return rows;
    }
