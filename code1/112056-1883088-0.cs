    public struct Test
    {
        private int a;
        private double b;
        public int A
        {
            get { return a; }
            internal set { a = value; }
        }
        public double B
        {
            get { return b; }
            internal set { b = value; }
        }
    }
