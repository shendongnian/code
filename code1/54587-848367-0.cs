        public static class DateTimeExtensions
        {
            public static DateTime GetNextAugust31(this DateTime date)
            {
                return new DateTime(date.Month <= 8 ? date.Year : date.Year + 1, 8, 31);
            }
        }
