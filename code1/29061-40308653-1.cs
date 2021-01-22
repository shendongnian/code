    public struct Range : IComparable<Range>
    {
        public int From;
        public int To;
        
        public Range(int point)
        {
            From = point;
            To = point;
        }
        public Range(int from, int to)
        {
            From = from;
            To = to;
        }
        public int CompareTo(Range other)
        {
            // If the ranges are overlapping, they are considered equal/matching
            if (From <= other.To && To >= other.From)
            {
                return 0;
            }
            // Since the ranges are not overlapping, we can compare either end
            return From.CompareTo(other.From);
        }
    }
    public class RangeDictionary
    {
        private static SortedDictionary<Range, string> _ranges = new SortedDictionary<Range, string>();
        public RangeDictionary()
        {
            _ranges.Add(new Range(1, 1000), "Alice");
            _ranges.Add(new Range(1001, 2000), "Bob");
            _ranges.Add(new Range(2001, 3000), "Carol");
        }
        public string Lookup(int key)
        {
            // We convert the value we want to lookup into a range,
            /* so it can be compared with the other ranges */
            var keyAsRange = new Range(key);
            string value;
            if (_ranges.TryGetValue(keyAsRange, out value))
            {
                return value;
            }
            return null;
        }
    }
