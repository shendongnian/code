    using System;
    
    namespace DelegateAnonymousFunctionExample
    {
        public delegate void D(int i, int b);
        class Program
        {
            static void Main(string[] args)
            {
                //Valid
                D f1 = (int a, int b) =>
                {
                    Console.WriteLine("Delegate invoked...");
                };
                f1(3, 4);
    
                //Valid
                D f2 = delegate { Console.WriteLine("Delegate invoked..."); };
    
                f2(3,4);
    
                Console.ReadKey();
            }
        }
    }
