    List<DateTime> dates = new List<DateTime> { DateTime.Now, DateTime.MinValue, DateTime.MaxValue };
    DateTime max = DateTime.MinValue; // Start with the lowest value possible...
    foreach(DateTime date in dates)
    {
        if (DateTime.Compare(date, max) == 1)
            max = date;
    }
    // max is maximum time in list, or DateTime.MinValue if dates.Count == 0;
