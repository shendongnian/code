    public class TimeOfDay
    {
        public DateTime time;
        public TimeOfDay(int Hour, int Minute, int Second)
        {
            time = DateTime.MinValue.Date.Add(new TimeSpan(Hour, Minute, Second));
        }
    }
