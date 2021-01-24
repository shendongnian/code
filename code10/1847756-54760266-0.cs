    public class B
        {
            public B(int num)
            {
                Console.Write("B");
            }
        }
    
        public class A : B
        {
            static A()
            {
                Console.Write("A");
            }
    
            public A(int num) : base(num)
            {
    
            }
        }
