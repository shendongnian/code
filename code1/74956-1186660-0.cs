    public class A
    {
        public class B
        {
            string m_b1;
            public string B1
            {
                get { return m_b1; }
                set { m_b1 = value; }
            }
        }
        B m_b = new B();
        public A()
        {
            m_b.B1 = "Hello World";
        }
    
        public B BProperty
        {
            get { return m_b; }
            set { m_b = value; }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Console.WriteLine(a.BProperty.B1);
        }
    }
