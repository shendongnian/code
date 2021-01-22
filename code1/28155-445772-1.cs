    class Foo
    {
        // Mark these as obsolete so that
        // you don't use them by mistake
        // in the class.
        [Obsolete]
        private double _a;
        [Obsolete]
        private double _b;
        [Obsolete]
        private double _c;
        #pragma warning disable 0612
        public double A
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
                // You may want to change
                // this to simply _a.
                _b = _c / (_a == 0 ? 1 : _a);
                _c = _a * _b;
            }
        }
        public double B
        {
            get
            {
                return _b;
            }
            set
            {
                _b = value;
                _a = _c / (_b == 0 ? 1 : _b);
                _c = _a * _b;
            }
        }
        public double C
        {
            get
            {
                return _c;
            }
            set
            {
                _c = value;
                _a = _c / (_b == 0 ? 1 : _b);
                _b = _c / (_a == 0 ? 1 : _a);
            }
        }
        #pragma warning restore 0612
    }
