    public class Period
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public static bool AreOverlapping(Period first, Period second)
        {
            if (first.StartTime > second.EndTime || 
                first.EndTime < second.StartTime) 
                    return false;
            return first.EndTime >= second.StartTime;
        }
    }
