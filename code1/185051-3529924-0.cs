    public static class TimeSpanExtensions
    {
        public static string ToDetailedString(this TimeSpan timeSpan)
        {
            if (timeSpan == null)
                throw new ArgumentNullException("timeSpan");
            var sb = new StringBuilder(30);
            var current = timeSpan.ToDaysString();
            if (!String.IsNullOrEmpty(current))
                sb.Append(current);
            current = timeSpan.ToHoursString();
            if (!String.IsNullOrEmpty(current))
            {
                if (sb.Length > 0)
                    sb.Append(" ");
                sb.Append(current);
            }
            current = timeSpan.ToMinutesString();
            if (!String.IsNullOrEmpty(current))
            {
                if (sb.Length > 0)
                    sb.Append(" ");
                sb.Append(current);
            }
            return sb.ToString();
        }
        public static string ToDaysString(this TimeSpan timeSpan)
        {
            if (timeSpan == null)
                throw new ArgumentNullException("timeSpan");
            int days = (int)timeSpan.TotalDays;
            switch (days)
            {
                case 0:
                    return String.Empty;
                case 1:
                    return "1 day";
                default:
                    return days + " days";
            }
        }
        public static string ToHoursString(this TimeSpan timeSpan)
        {
            if (timeSpan == null)
                throw new ArgumentNullException("timeSpan");
            switch (timeSpan.Hours)
            {
                case 0:
                    return String.Empty;
                case 1:
                    return "1 hour";
                default:
                    return timeSpan.Hours + " hours";
            }
        }
        public static string ToMinutesString(this TimeSpan timeSpan)
        {
            if (timeSpan == null)
                throw new ArgumentNullException("timeSpan");
            switch (timeSpan.Minutes)
            {
                case 0:
                    return String.Empty;
                case 1:
                    return "1 minute";
                default:
                    return timeSpan.Minutes + " minutes";
            }
        }
    }
