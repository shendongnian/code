    class Program
    {
        static void Main(string[] args)
        {
            E myE = new E();
    
            Console.WriteLine("E.N1.Field1 = " + myE.N1.Field1);
            Console.WriteLine("E.N2.Field1 = " + myE.N2.Field1);
        }
    
        public interface IN
        {
            int Field1 { get; }
        }
    
        public class E
        {
            private N _n1 = new N();
            private N _n2 = new N();
    
            public E()
            {
                _n1.Field1 = 42;
                _n2.Field1 = 23;
            }
    
            public IN N1
            {
                get { return _n1; }
            }
    
            public IN N2
            {
                get { return _n2; }
            }
    
            private class N : IN
            {
                private int _field1;
    
                public int Field1
                {
                    get { return _field1; }
                    set { _field1 = value; }
                }
            }
        }
    }
