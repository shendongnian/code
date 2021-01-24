    public class RangeList<T>
    {
        private List<T> list = new List<T>();
        public abstract int GetLower(T item);
        public abstract int GetUpper(T item);
        public T this[int index]
        {
            get
            {
                return list.SingleOrDefault(x => index >= GetLower(x) && index <= GetUpper(x));
            }
        }
        public void Add(T item)
        {
            if (list.Any(x => GetUpper(item) >= GetLower(x) && GetLower(item) <= GetUpper(x)))
                throw new Exception("Attempt to add item with overlapping range");
        }
    }
    public class Phase
    {
        public int y1;
        public int y2;
        public string phasename;
    }
    public class PhaseList : RangeList<Phase>
    {
        public override int GetLower(Phase item)
        {
            return item.y1;
        }
        public override int GetUpper(Phase item)
        {
            return item.y1;
        }
    }
