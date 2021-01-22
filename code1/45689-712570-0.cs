    using System;
    
    namespace Test
    {
        class Generic<A, B>
        {
            public string Method(A a, B b)
            {
                return this.DefaultMethod(a, b);
            }
    
            protected string DefaultMethod(A a, B b)
            {
                return a.ToString() + b.ToString();
            }
    
            public string Method(B b, A a)
            {
                return b.ToString() + a.ToString();
            }
        }
    
        class Generic<A> : Generic<A, A>
        {
            public new string Method(A a, A b)
            {
                return base.DefaultMethod(a, b);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Generic<int, double> t1 = new Generic<int, double>();
                Console.WriteLine(t1.Method(1.23, 1));
    
                Generic<int> t2 = new Generic<int>();
                Console.WriteLine(t2.Method(1, 2));
            }
        }
    }
