    // This is to get the 1st Monday in each month from today through one year from today
    DateTime beg = DateTime.Now;
    DateTime end = DateTime.Now.AddYears(1);
    List<DateTime> dates = GetDatesForNthDOWOfMonth(1, DayOfWeek.Monday, beg, end);
    // To see the list of dateTimes, for verification
    foreach (DateTime d in dates)
    {
        MessageBox.Show(string.Format("Found {0}", d.ToString()));
    }
