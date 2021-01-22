    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        public class A
        {
            internal int var_a = 666;
    
            public A() 
            {
                B b = new B(this);
                b.method123();
                Console.WriteLine(b.var_b);
            }
    
            public class B
            {
                private A a = null;
    
                public B(A a)
                {
                    this.a = a;
                }
    
                internal int var_b = 999;
    
                public void method123() 
                {
                    Console.WriteLine(a.var_a);
                } 
            }
        }
    
    
        class Program
        {
    
            static void Main(string[] args)
            {
                new A();
            }
        }
    }
