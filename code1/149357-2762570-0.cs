    public class Range
    {
        public int End;
        public int Start;
        public Range(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
    public class RangeGapFinder
    {
        public Range FindGap(Range range1, Range range2)
        {
            if (range1 == null)
            {
                throw new ArgumentNullException("range1", "range1 cannot be null");
            }
            if (range2 == null)
            {
                throw new ArgumentNullException("range2", "range2 cannot be null");
            }
            if (range2.Start < range1.Start)
            {
                return FindGap(range2, range1);
            }
            if (range1.End < range1.Start)
            {
                range1 = new Range(range1.End, range1.Start);
            }
            if (range2.End < range2.Start)
            {
                range2 = new Range(range2.End, range2.Start);
            }
            if (range1.End + 1 >= range2.Start)
            {
                return null; // no gap
            }
            return new Range(range1.End + 1, range2.Start - 1);
        }
    }
