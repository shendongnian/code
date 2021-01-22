    public void blabla(List<TimeEntry> hoho)
    {
        Dictionary<DateTime, double> timeEntries = new Dictionary<DateTime, double>();
        hoho.ForEach((timeEntry) =>
            {
                timeEntries[timeEntry.Day] += timeEntry.Hours;
            });
    }
