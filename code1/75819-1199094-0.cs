    class L0
    {
        public int f0;
        private int _p0;
        public int p0
        {
            get { return _p0; }
            set { _p0 = value; }
        }
    }
    class L1 : L0
    {
        public int f1;
        private int _p1;
        public int p1
        {
            get { return _p1; }
            set { _p1 = value; }
        }
    }
    class L2 : L1
    {
        public int f2;
        private int _p2;
        public int p2
        {
            get { return _p2; }
            set { _p2 = value; }
        }
    }
