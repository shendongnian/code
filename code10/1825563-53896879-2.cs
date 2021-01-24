    public static class Extensions
    {
        public static TimeSpan AddWithFrames(this TimeSpan x, TimeSpan ts)
        {
            int fr = ts.Seconds + x.Seconds;
            TimeSpan result = x.Add(ts).Add(new TimeSpan(0,0,fr/25,0));
            return new TimeSpan(result.Days, result.Hours, result.Minutes, fr % 25);
        }
    }
