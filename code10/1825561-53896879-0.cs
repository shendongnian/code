    public static class Extensions
    {
        public static TimeSpan Add(this TimeSpan x, TimeSpan ts)
        {
            int fr = ts.Milliseconds + x.Milliseconds;
            TimeSpan result = x.Add(ts).Add(new TimeSpan(0,0,0,fr/25,0));
            return new TimeSpan(result.Days, result.Hours, result.Minutes, result.Seconds , fr % 25);
        }
    }
