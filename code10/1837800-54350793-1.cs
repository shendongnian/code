    public class LegacyIdDescendingComparer : IComparer<DataClass>
    {
        public LegacyIdDescendingComparer() { }
        public int Compare(DataClass x, DataClass y)
        {
            if (x.ID == y.ID)
            {
                return 0;
            }
            // The last digit, forgive my naming conventions
            // If the number ends with 10 then the last digit is ten else it is whatever the value in units place
            // I did this to make this work with the following case: 28, 29, 210, 30, 31
            // 210 will be 10, 31 will be 1
            var x_tens = x.ID % 100 == 10 ? 10 : x.ID % 10;
            var y_tens = y.ID % 100 == 10 ? 10 : y.ID % 10;
            
            // The number divided by 10
            // 210 is 2, 29 is also 2
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
