    class A
    {
        private int m_val;
        public int Val
        {
            get { return m_val; }
            protected set { m_val = value; }
        }
    }
    
    class B : A
    {
        public new int Val
        {
            get { return base.Val;}
            set { base.Val = value; }
        }
    }
