    using System;
    
    namespace ConsoleApplication1
    {
        public enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
    
        class Program
        {
            static void Main(string[] args)
            {
                Days day = Days.Monday;
                Console.WriteLine((int)day);
                Console.ReadLine();
            }
        }
    }
