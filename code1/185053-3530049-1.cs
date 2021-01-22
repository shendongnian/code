    public static class TimeSpanEx
    {
        public static string FormattedString(this TimeSpan ts)
        {
            int days = (int)ts.TotalDays;
            int hrs = (int)ts.Hours;
            int mins = (int)ts.Minutes;
            StringBuilder sb = new StringBuilder();
            if (days > 0)
            {
                sb.Append(days.ToString() + (days == 1 ? " day, " : " days, "));
            }
            if (hrs > 0 || days > 0)
            {
                sb.Append(hrs.ToString() + (hrs == 1 ? " hour, " : " hours, "));
            }
            sb.Append(mins.ToString() + (mins == 1 ? " min" : " mins"));
            return sb.ToString();
        }
    }
