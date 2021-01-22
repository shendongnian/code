    class Foo
    {
        private double m_a;
        public double A
        {
            get { return m_a; }
            set { m_a = value; }
        }
        private double m_b;
        public double B
        {
            get { return m_b; }
            set { m_b = value; }
        }
        
        public double C
        {
            get { return A * B; }
        }
    }
