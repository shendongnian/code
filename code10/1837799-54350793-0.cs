    public class LegacyIdDescendingComparer : IComparer<DataClass>
    {
        public LegacyIdDescendingComparer() { }
        public int Compare(DataClass x, DataClass y)
        {
            if (x.ID == y.ID)
            {
                return 0;
            }
            var x_tens = x.ID % 100 == 10 ? 10 : x.ID % 10;
            var y_tens = y.ID % 100 == 10 ? 10 : y.ID % 10;
            var x_quo = x.ID % 100 == 10 ? x.ID / 100 : x.ID / 10;
            var y_quo = y.ID % 100 == 10 ? y.ID / 100 : y.ID / 10;
            if (x_quo > y_quo)
            {
                return -1;
            }
            if (x_quo == y_quo)
            {
                return y_tens.CompareTo(x_tens);
            }
            return 1;
        }
    }
