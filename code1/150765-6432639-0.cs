    public static class TimeSpanExtensions
    {
        static int[] weights = { 60 * 60 * 1000, 60 * 1000, 1000, 1 };
        public static TimeSpan ToTimeSpan(this string s)
        {
            string[] parts = s.Split('.', ':');
            long ms = 0;
            for (int i = 0; i < parts.Length && i < weights.Length; i++)
                ms += Convert.ToInt64(parts[i]) * weights[i];
            return TimeSpan.FromMilliseconds(ms);
        }
    }
