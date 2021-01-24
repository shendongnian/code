    public DateTime GetDay(DateTime source, DayOfWeek dayOfWeek)
    {
        // Here we are relying on the DayOfWeek enum being Monday=1, Tuesday=2 etc
    	return source.AddDays((int)dayOfWeek - (int)source.DayOfWeek);
    }
