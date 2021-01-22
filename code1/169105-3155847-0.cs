    class DateEvent : IComparable<DateEvent>
    {
        public Date Date;
        public int DateRangeId;
        public bool IsBegin; // is this the start of a range?
        public int CompareTo(DateEvent other)
        {
            if (Date < other.Date) return -1;
            if (Date > other.Date) return +1;
            if (IsBegin && !other.IsBegin) return -1;
            if (!IsBegin && other.IsBegin) return +1;
            return 0;
        }
    }
