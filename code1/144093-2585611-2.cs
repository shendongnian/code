    class CustomComparer
        : IComparer<string>
    {
        private bool isAscending;
        public CustomComparer(bool isAscending = true)
        {
            this.isAscending = isAscending;
        }
        public int Compare(string x, string y)
        {
            long ix = CustomParser(x) * (isAscending ? 1 : -1);
            long iy = CustomParser(y) * (isAscending ? 1 : -1);
            return ix.CompareTo(iy) ;
        }
        private long CustomParser(string s)
        {
            if (string.IsNullOrEmpty(s))
                return isAscending ? int.MaxValue : int.MinValue;
            else
                return int.Parse(s);
        }
    }
