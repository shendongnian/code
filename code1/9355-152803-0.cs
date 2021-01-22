      public enum DateTimePrecision
        {
            Hour, Minute, Second
        }
        public static DateTime TrimDate(DateTime date, DateTimePrecision precision)
        {
            switch (precision)
            {
              case DateTimePrecision.Hour:
                    return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
                case DateTimePrecision.Minute:
                    return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
                case DateTimePrecision.Second:
                    return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
                default:
                    break;
            }
        }
