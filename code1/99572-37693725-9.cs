    private static int[,] weekdayOffsets = {
         // Su M  Tu W  Th F  Sa
    	{0, 1, 2, 3, 4, 5, 5}, // Su
    	{4, 0, 1, 2, 3, 4, 4}, // M 
    	{3, 4, 0, 1, 2, 3, 3}, // Tu
    	{2, 3, 4, 0, 1, 2, 2}, // W 
    	{1, 2, 3, 4, 0, 1, 1}, // Th
    	{0, 1, 2, 3, 4, 0, 0}, // F 
    	{0, 1, 2, 3, 4, 5, 0}, // Sa
    };
    
    public static int GetWeekDayDiff(DateTime dtStart, DateTime dtEnd)
    {
        int daysDiff = (int)(dtEnd - dtStart).TotalDays;
        return daysDiff >= 0
    	? +5 * (daysDiff / 7) + weekdayOffsets[(int) dtStart.DayOfWeek, (int) dtEnd.DayOfWeek]
    	: -5 * (daysDiff / 7) + weekdayOffsets[6 - (int) dtStart.DayOfWeek, 6 - (int) dtEnd.DayOfWeek];
    
    }
