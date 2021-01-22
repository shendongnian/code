    public struct MyInt
    {
        private int _defaultInt;
        public int DefaultInt
        {
            get
            {
                if (_defaultInt == 0)
                    return 5;
                else
                    return _defaultInt;
            }
            set
            {
                _defaultInt = value;
            }
        }
    }
