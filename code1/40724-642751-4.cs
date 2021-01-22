    public static class eRat
    {
        public static readonly eRatValue A;
        public static readonly eRatValue B;
        public static readonly eRatValue C;
        public static readonly eRatValue D;
        static eRat()
        {
            D = new eRatValue(8, null);
            C = new eRatValue(5, D);
            B = new eRatValue(3, C);
            A = new eRatValue(0, B);
        }
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
