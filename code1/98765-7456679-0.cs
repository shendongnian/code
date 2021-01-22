    public struct MyInt
    {
        private const int INT_DEFAULT = 5;
        private int _defaultInt;
        public int DefaultInt
        {
            get { return _defaultInt + INT_DEFAULT; }
            set { _defaultInt = value - INT_DEFAULT; }
        }
    }
