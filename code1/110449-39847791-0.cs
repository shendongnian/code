    public static DateTimeExtensions 
    {
        public static IEnumerable<DateTime> RangeTo(this DateTime from, DateTime to, Func<DateTime, DateTime> step = null)
        {
            if (step == null)
            {
                step = x => x.AddDays(1);
            }
            while (from < to)
            {
                yield return from;
                from = step(from);
            }
        }
        
        public static IEnumerable<DateTime> RangeFrom(this DateTime to, DateTime from, Func<DateTime, DateTime> step = null)
        {
            return from.RangeTo(to, step);
        }
    }
