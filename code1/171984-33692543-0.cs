    List<DateTime> allDates = new List<DateTime>();
    for (DateTime i = startingDate; i <= endingDate; i = i.AddDays(1))
    {
        allDates.Add(i);
    }
    return allDates.AsReadOnly();
}
