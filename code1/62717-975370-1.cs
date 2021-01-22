    // preprocessor_if.cs
    #define DEBUG
    #define VC_V7
    using System;
    public class MyClass 
    {
        static void Main() 
        {
    #if (DEBUG && !VC_V7)
            Console.WriteLine("DEBUG is defined");
    #elif (!DEBUG && VC_V7)
            Console.WriteLine("VC_V7 is defined");
    #elif (DEBUG && VC_V7)
            Console.WriteLine("DEBUG and VC_V7 are defined");
    #else
            Console.WriteLine("DEBUG and VC_V7 are not defined");
    #endif
        }
    }
