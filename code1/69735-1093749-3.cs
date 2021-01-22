    private int DaysLate(DateTime dueDate, DateTime returnDate)
    {
        var ts = returnDate - dueDate;
        int dayCount = 0;
        for (int i = 1; i <= ts.Days; i++)
        {
            if (dueDate.AddDays(i).DayOfWeek != DayOfWeek.Sunday)
                dayCount++;
        }
        return dayCount;
    }
