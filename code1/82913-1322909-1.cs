    public struct MyDayOfWeek
    {
        private int iVal;
        private bool def;
      
        internal int Value
        {
            get { return iVal; }
            set { iVal = value; }
        }
        public bool Defined
        {
            get { return def; }
            set { def = value; }
        }
        public bool IsNull { get { return !Defined; } }
        private MyDayOfWeek(int i)
        {
           iVal = i;
           def = true;
        }           
        #region constants
        private const int Monday = new MyDayOfWeek(1);
        private const int Tuesday = new MyDayOfWeek(2);
        private const int Wednesday = new MyDayOfWeek(3);
        private const int Thursday = new MyDayOfWeek(4);
        private const int Friday = new MyDayOfWeek(5);
        private const int Saturday = new MyDayOfWeek(6);
        private const int Sunday = new MyDayOfWeek(7);
        #endregion constants
        public override string ToString()
        {
            switch (iVal)
            {
                case (1): return "Monday";
                case (2): return "Tuesday";
                case (3): return "Wednesday";
                case (4): return "Thursday";
                case (5): return "Friday";
                case (6): return "Saturday";
                case (7): return "Sunday";
            }
        }
    }
