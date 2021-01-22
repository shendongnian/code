        public class DateTimeComparer : Comparer<DateTime>
        {
            public enum Precision
            {
                Years = 0,
                Months,
                Days,
                Hours,
                Minutes,
                Seconds,
                Millisecons,
                Ticks
            }
            private Precision _precision;
            public DateTimeComparer(Precision precision =  Precision.Ticks)
            {
                _precision = precision;
            }
            public override int Compare(DateTime x, DateTime y)
            {
                if (_precision == Precision.Ticks)
                {
                    return x.CompareTo(y);
                }
                var xx = AssembleValue(x, _precision);
                var yy = AssembleValue(y, _precision);
                return xx.CompareTo(yy);
            }
            private static DateTime AssembleValue(DateTime input, Precision precision)
            {
                var p = (int)precision;
                var i = 1;
                return new DateTime(input.Year,
                                    p >= i++ ? input.Month : 1,
                                    p >= i++ ? input.Day : 1,
                                    p >= i++ ? input.Hour : 0,
                                    p >= i++ ? input.Minute : 0,
                                    p >= i++ ? input.Second : 0,
                                    p >= i++ ? input.Millisecond : 0);
            }
        }
