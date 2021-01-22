    private DateTime getStartOfWeek(bool useSunday)
    {
        DateTime now = DateTime.Now;
        int dayOfWeek = (int)now.DayOfWeek;
        if(!useSunday)
            dayOfWeek--;
        if(dayOfWeek < 0)
        {// day of week is Sunday and we want to use Monday as the start of the week
		// Sunday is now the seventh day of the week
            dayOfWeek = 6;
        }
        return now.AddDays(-1 * (double)dayOfWeek);
    }
