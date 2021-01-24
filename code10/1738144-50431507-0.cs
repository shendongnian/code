    public class TimeRange
    {
        public TimeRange(TimeSpan from, TimeSpan to)
        {
            From = from;
            To = to;
        }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
    public TimeRange GetRange(DateTime d, int minutesInterval)
    {
        TimeSpan time = d.TimeOfDay;
        var from = time.TotalMinutes - (time.TotalMinutes % minutesInterval);
        var to = from + minutesInterval;
        return new TimeRange(TimeSpan.FromMinutes(from), TimeSpan.FromMinutes(to));
    }
