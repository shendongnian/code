    // preprocessor_if.cs
    #define DEBUG
    #define MYTEST
    using System;
    public class MyClass 
    {
        static void Main() 
        {
    #if (DEBUG && !MYTEST)
            Console.WriteLine("DEBUG is defined");
    #elif (!DEBUG && MYTEST)
            Console.WriteLine("MYTEST is defined");
    #elif (DEBUG && MYTEST)
            Console.WriteLine("DEBUG and MYTEST are defined");
    #else
            Console.WriteLine("DEBUG and MYTEST are not defined");
    #endif
        }
    }
