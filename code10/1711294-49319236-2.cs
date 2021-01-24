    public interface IRangeable
    {
        int Lower { get; }
        int Upper { get; }
    }
    public class Phase : IRangeable
    {
        public int y1;
        public int y2;
        public string phasename;
        int IRangeable.Lower => y1;
        int IRangeable.Upper => y2;
    }
    public class RangeList<T> where T : IRangeable
    {
        private List<T> list = new List<T>();
        public T this[int index]
        {
            get
            {
                return list.SingleOrDefault(x => index >= ((IRangeable)x).Lower && index <= ((IRangeable)x).Upper);
            }
        }
        public void Add(T item)
        {
            if (list.Any(x => ((IRangeable)item).Higher >= ((IRangeable)x).Lower && ((IRangeable)item).Lower <= ((IRangeable)x).Upper))
                throw new Exception("Attempt to add item with overlapping range");
        }
    }
