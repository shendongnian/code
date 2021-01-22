    class Program
    {
        class P
        {}
        class Q : P
        {}
        class A 
        { 
            public void Fee(Q q)
            {
                Console.WriteLine("A::Fee");
            }
        }
        class B : A 
        {   
            public void Fee(P p)
            {
                Console.WriteLine("B::Fee");
            }
        }
        static void Main(string[] args) 
        { 
            B b = new B();   
            /* which Fee is chosen? */  
 
            b.Fee(new Q());
            Console.ReadKey();
        }
    }
