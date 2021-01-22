    class ConcClassB : IClass
    {
        double IClass.Top
        {
            get { return Top; }
        }
        double IClass.Bottom
        {
            get { return Bottom; }
        }
        public double Top
        {
            get { ... }
            set { ... }
        }
        public double Bottom
        {
            get { ... }
            set { ... }
        }
    }
