    public class DateTimeComparer : Comparer<DateTime>
    {
        private Prescision _Prescision;
        public enum Prescision : sbyte
        {
            Millisecons,
            Seconds,
            Minutes,
            Hour,
            Day,
            Month,
            Year,
            Ticks
        }
        Func<DateTime, DateTime>[] actions = new Func<DateTime, DateTime>[]
            {
                (x) => { return x.AddMilliseconds(-x.Millisecond);},
                (x) => { return x.AddSeconds(-x.Second);},
                (x) => { return x.AddMinutes(-x.Minute);},
                (x) => { return x.AddHours(-x.Hour);},
                (x) => { return x.AddDays(-x.Day);},
                (x) => { return x.AddMonths(-x.Month);},
            };
        public DateTimeComparer(Prescision prescision = Prescision.Ticks)
        {
            _Prescision = prescision;
        }
        public override int Compare(DateTime x, DateTime y)
        {
            if (_Prescision == Prescision.Ticks)
            {
                return x.CompareTo(y);
            }
            for (sbyte i = (sbyte)(_Prescision - 1); i >= 0; i--)
            {
                x = actions[i](x);
                y = actions[i](y);
            }
            return x.CompareTo(y);
        }
    }
