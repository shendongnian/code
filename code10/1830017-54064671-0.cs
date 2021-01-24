    public static void Main(string[] args)
            {
                DateTime timeArrived = new DateTime(2019, 1, 1, 7, 3, 1);
                DateTime timeExit = new DateTime(2019, 1, 3, 12, 34, 1);
    
                DailyMoment startMeal1 = new DailyMoment(6, 0, 0);
                DailyMoment endMeal1 = new DailyMoment(8, 0, 0);
                DailyMoment startMeal2 = new DailyMoment(12, 0, 0);
                DailyMoment endMeal2 = new DailyMoment(14, 0, 0);
                DailyMoment startMeal3 = new DailyMoment(17, 0, 0);
                DailyMoment endMeal3 = new DailyMoment(19, 0, 0);
    
    
                int daysDiff = (timeExit - timeArrived).Days;
    
                int meals1Count = daysDiff;
                int meals2Count = daysDiff;
                int meals3Count = daysDiff;
    
    
                if (timeArrived.TimeOfDay <= endMeal1.TimeOfDay && timeExit.TimeOfDay >= startMeal1.TimeOfDay) meals1Count++;
                if (timeArrived.TimeOfDay <= endMeal2.TimeOfDay && timeExit.TimeOfDay >= startMeal2.TimeOfDay) meals2Count++;
                if (timeArrived.TimeOfDay <= endMeal3.TimeOfDay && timeExit.TimeOfDay >= startMeal3.TimeOfDay) meals3Count++;
            }
    
    public class DailyMoment
        {
            private DateTime moment;
            public DailyMoment(int Hour, int Minute, int Second)
            {
                moment = new DateTime(1, 1, 1, Hour, Minute, Second);
            }
            public int Hour
            {
                get { return moment.Hour; }
            }
            public int Minute
            {
                get { return moment.Minute; }
            }
            public int Second
            {
                get { return moment.Second; }
            }
    
            public long Ticks
            {
                get { return moment.Ticks; }
            }
    
            public TimeSpan TimeOfDay
            {
                get { return moment.TimeOfDay; }
            }
        }
