    static void Main(string[] args)
    {
        DateTime date1 = new DateTime(2018, 04, 18);
        DateTime date2 = new DateTime(2018, 04, 19);
    
                
        System.Console.WriteLine((GetDiff(new DateTime(2018, 04, 18), new DateTime(2018, 04, 18)))); // 0
        System.Console.WriteLine((GetDiff(new DateTime(2018, 04, 22), new DateTime(2018, 04, 23)))); // 1
        System.Console.WriteLine((GetDiff(new DateTime(2018, 04, 16), new DateTime(2018, 04, 22)))); // 0
        System.Console.WriteLine((GetDiff(new DateTime(2018, 04, 18), new DateTime(2018, 05, 03)))); // 2
    }
    
    private static int GetDiff(DateTime date1, DateTime date2)
    {
        date1 = SetDayToMonday(date1);
        date2 = SetDayToMonday(date2);
    
        return (int)((date2 - date1).TotalDays / 7);
    }
    
    private static DateTime SetDayToMonday(DateTime date)
    { 
        var weekDay = date.DayOfWeek;
        if (weekDay == DayOfWeek.Sunday)
            return date.AddDays(-6);
        else
            return date.AddDays(-((int)weekDay-1));
    }
