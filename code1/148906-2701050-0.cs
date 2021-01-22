    class Range
    {
        public DateTime Begin { get; private set; }
        public DateTime End { get; private set; }
        public Range(DateTime begin, DateTime end)
        {
            Begin = begin;
            End = end;
        }
    
        public bool Contains(Range range)
        {
            return range.Begin >= Begin && range.End <= End;
        }
    }
