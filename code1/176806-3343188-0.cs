    string inputDate = "May 2010";
    int year = 0;
    DateTime date = new DateTime();
    // Try to parse just by year.
    // Otherwise parse by the input string.
    if (int.TryParse(inputDate, out year))
    {
        date = new DateTime(year, 12, 31);
    }
    else
    {
        // Parse the date and set to the last day of the month.
        if (DateTime.TryParse(inputDate, out date))
        {
            date = date.AddMonths(1).AddMilliseconds(-1);
        }
        else
        {
            // Throw exception for invalid date?
        }
    }
