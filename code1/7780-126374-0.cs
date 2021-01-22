    namespace ConsoleApplication2
    {
        using System;
        using System.Collections.Generic;
        using System.Collections;
    
        class B
        {
        }
    
        class A : IEnumerable<B>
        {
            private List<B> _myList = new List<B>();
    
            public void Add(B o)
            {
                _myList.Add(o);
            }
    
            public IEnumerator<B> GetEnumerator()
            {
                return _myList.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A();
                a.Add(new B());
    
                foreach (B o in a)
                {
                    Console.WriteLine(o.GetType().ToString());
                }
    
                Console.ReadLine();
            }
        }
    }
