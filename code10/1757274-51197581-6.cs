    public class DateGroupCompositeKey<TKey>
    {
        public DateGroupKey DateKey { get; set; }
        public TKey ObjectKey { get; set; }
    }
    public class DateGroupKey
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }
    }
