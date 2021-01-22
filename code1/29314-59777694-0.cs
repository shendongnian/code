     public static string ConvertTime(long secs)
        {
            TimeSpan ts = TimeSpan.FromSeconds(secs);
            string displayTime = $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}";
            return displayTime;
        }
