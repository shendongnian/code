    public static class DateTimeExtensions
        {
            public static int ToYearLastTwoDigit(this DateTime date)
            {
                var temp = date.ToString("yy");
                return int.Parse(temp);
            }
        }
