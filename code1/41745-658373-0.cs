        DateTime date = DateTime.Now.AddDays(-7);
        while (date.DayOfWeek != DayOfWeek.Monday)
        {
            date = date.AddDays(-1);
        }
        DateTime startDate = date;
        DateTime endDate = date.AddDays(7);
