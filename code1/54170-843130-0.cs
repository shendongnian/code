    using System;
    
    namespace ExceptionCallstack
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    func1();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops");
                    Console.ReadKey();
                }
            }
    
            static void func1()
            {
                func2();
            }
    
            static void func2()
            {
                func3();
            }
    
            static void func3()
            {
                throw new Exception("Boom!");
            }
        }
    }
