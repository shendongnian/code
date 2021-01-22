    DateTime date = new DateTime(2009, 2, 1);
    // Work out the first monday (might have to play with the calc a bit)
    date = date.AddDays(((int)date.DayOfWeek + (int)DayOfWeek.Monday) % 7);
    List<DateTime> dates = new List<DateTime>();
    do
    {
        dates.Add(date);
        date = date.AddDays(7);
    } while (date.Month == 2);
