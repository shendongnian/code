    public class B1
    {
        public static void myFunc(){ ; }
    }
    
    public class B2
    {
        private B1 m_b1;
    
        public B1 b1
        {
            get { return m_b1; }
            set { m_b1 = value; }
        }
    
        public void Foo()
        {
            B1.MyFunc(); //this is Ok, no need to use namespace
        }
    }
