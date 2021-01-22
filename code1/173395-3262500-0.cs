        public static class DateTimeExtensions
        {
            public static DateTime ToMyDateFormat(this DateTime d)
            {
                return d.ToString("dd-MMM-yyyy");
            }
        }
