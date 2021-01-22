    namespace System
    {
        public static class DateTimeExtensions
        {
            public static string ToString(this DateTime dateTime, string format, bool useExtendedSpecifiers)
            {
                return dateTime.ToString(format)
                    .Replace("nn", "thstndrdthththththth".Substring((dateTime.Day % 10) * 2, 2));
            }
        }
    }
