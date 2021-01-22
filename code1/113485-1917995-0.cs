    using System;
    
    namespace ConsoleApplication11
    {
        class Program
        {
            public static Stringg ReturnsTheWrongType()
            {
                return null;
            }
    
            static void Main(string[] args)
            {
                CallSomeMethodThatDoesntExist();
            }
    
            public static Stringg AlsoReturnsTheWrongType()
            {
                return null;
            }
        }
    }
