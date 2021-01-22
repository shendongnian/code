    using System;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var t = typeof(MyClass);
    
                foreach (var m in t.GetMethods())
                {
                    Console.WriteLine(m.Name);
                }
                Console.ReadLine();
            }
        }
    
    
        public class MyClass
        {
            public int Add(int x, int y)
            {
                return x + y;
            }
    
            public int Subtract(int x, int y)
            {
                return x - y;
            }
        }
    }
