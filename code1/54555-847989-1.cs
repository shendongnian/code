    class InnerClass
    {
        private int _a;
        public int a
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
            }
        }
        
        private int _b;
        public int b
        {
            get
            {
                return _b;
            }
            set
            {
                _b = value;
            }
        }
    }
    class OuterClass
    {
        private InnerClass _innerClass;
        public InnerClass innerClass
        {
            get
            {
                return _innerClass;
            }
            set
            {
                _innerClass = value;
            }
        }
    }
