    public static class eRat
    {
        public static readonly eRatValue A = new eRatValue(0, B);
        public static readonly eRatValue B = new eRatValue(3, C);
        public static readonly eRatValue C = new eRatValue(5, D);
        public static readonly eRatValue D = new eRatValue(8, null);
        #region Nested type: ERatValue
        public class eRatValue
        {
            private readonly eRatValue next;
            private readonly int value;
            public eRatValue(int value, eRatValue next)
            {
                this.value = value;
                this.next = next;
            }
            public int Value
            {
                get { return value; }
            }
            public eRatValue Next
            {
                get { return next; }
            }
            public static implicit operator int(eRatValue eRatValue)
            {
                return eRatValue.Value;
            }
        }
        #endregion
    }
