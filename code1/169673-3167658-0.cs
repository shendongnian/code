    #define TEST
    using System;
    public class MyClass 
    { 
        public static void Main() 
        {
            #if (TEST)
                Console.WriteLine("TEST is defined"); 
            #else
                Console.WriteLine("TEST is not defined");
            #endif
        }
    }
