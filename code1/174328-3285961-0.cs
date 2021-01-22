    public struct Coinage
    {
        private int _val;
    
        public int Copper
        {
            get { return _val % 100; }
            set { _val += value }
        }
        public int Silver 
        { 
            get { return (_val % 10000) / 100; } 
            set { _val += value * 100; }
        }
        public int Gold
        {
            get { return (_val % 1000000) / 10000; }
            set { _val += value * 10000; }
        }
        public int Platinum 
        {
            get { return (_val % 100000000) / 1000000; }
            set { _val += value * 1000000; }
        }
    }
