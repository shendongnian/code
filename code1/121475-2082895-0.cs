    using System;
    using System.Diagnostics;
    
    interface IFoo
    {
        int Foo(int x);
    }
    
    class Program : IFoo
    {
        const int Iterations = 1000000000;
        
        public int Foo(int x)
        {
            return x * 3;
        }
        
        static void Main(string[] args)
        {
            int x = 3;
            IFoo ifoo = new Program();
            Func<int, int> del = ifoo.Foo;
            // Make sure everything's JITted:
            ifoo.Foo(3);
            del(3);
    
            Stopwatch sw = Stopwatch.StartNew();        
            for (int i = 0; i < Iterations; i++)
            {
                x = ifoo.Foo(x);
            }
            sw.Stop();
            Console.WriteLine("Interface: {0}", sw.ElapsedMilliseconds);
    
            x = 3;
            sw = Stopwatch.StartNew();        
            for (int i = 0; i < Iterations; i++)
            {
                x = del(x);
            }
            sw.Stop();
            Console.WriteLine("Delegate: {0}", sw.ElapsedMilliseconds);
        }
    }
