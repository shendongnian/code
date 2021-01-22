    public class Comparer : IComparer<string>
    {
        private Dictionary<string, int> _order;
        public Comparer()
        {
            List<string> list = new List<string>()
            {
                "CS01",
                "CS58",
                "CS11"
            };
            _order = new Dictionary<string, int>();
            for (int i = 0; i < list.Count; i++)
            {
                _order.Add(list[i], i);
            }
        }
        public int Compare(string x, string y)
        {
            if (x.Length < 4 || y.Length < 4)
                return x.CompareTo(y);
            string xPrefix = x.Substring(0, 4);
            string yPrefix = y.Substring(0, 4);
            int xSequence;
            int ySequence;
            if (_order.TryGetValue(xPrefix, out xSequence)
                && _order.TryGetValue(yPrefix, out ySequence))
            {
                return xSequence.CompareTo(ySequence);
            }
            else
            {
                return x.CompareTo(y);
            }
        }
    }
