    public class DataComparer : IComparer<Data>
    {
        public Int32 Compare(Data a, Data b)
        {
            if (a == null && b == null)
                return 0;
            if (a == null)
                return -1;
            if (b == null)
                return +1;
            return a.Priority.CompareTo(b.Priority);
        }
    }
    SortedDictionary<Data, Data> priQueue = new SortedDictionary<Data, Data>(
        new DataComparer());
