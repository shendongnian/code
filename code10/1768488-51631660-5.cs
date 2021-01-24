    public class DateGroupKeyComparer : IEqualityComparer<DateGroupKey>
    {
        public bool Equals(DateGroupKey x, DateGroupKey y)
        {
            return x.Year == y.Year &&
                x.Month == y.Month &&
                x.Week == y.Week &&
                x.Day == y.Day;
        }
        public int GetHashCode(DateGroupKey obj)
        {
            unchecked
            {
                var h = 0;
                h = (h * 31) ^ obj.Year;
                h = (h * 31) ^ obj.Month;
                h = (h * 31) ^ obj.Week;
                h = (h * 31) ^ obj.Day;
                return h;
            }
        }
    }
