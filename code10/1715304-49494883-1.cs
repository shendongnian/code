    public static void SetScheduleTicketsDate()
    {
        DateTime currentDay = DateTime.Now;
        currentDay = SchedulePatchGroup(currentDay);
        Console.WriteLine(currentDay);
    }
    
    private static DateTime SchedulePatchGroup(DateTime currentDay)
    {
        return currentDay.AddDays(10);
    }
