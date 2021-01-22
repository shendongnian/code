    using System;
    
    namespace static_init
    {
        public class bar
        {
            public bar()
            {
                Console.WriteLine("bar construct");
            }
        }
    
        class Program
        {
            public static bar blah = new bar();
    
            // This static constructor will make sure that the type Program 
            // is initialized before it is first used.
            //
            static Program()
            { }
    
            static void Main(string[] args)
            {
                Console.WriteLine("main");
                Console.ReadLine();
            }
        }
    }
