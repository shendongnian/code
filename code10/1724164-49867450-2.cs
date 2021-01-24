    public class Period
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public static bool AreOverlapping(Period first, Period second)
        {
            if (first == null || second == null) return false;
            // These two conditions define "overlapping" and must be true
            return first.StartTime <= second.EndTime &&
                   first.EndTime >= second.StartTime;
        }
    }
