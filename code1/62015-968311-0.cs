    using System;
    
    class Test
    {
        [Obsolete]
        static void Foo(string x)
        {
        }
        
        static void Main(string[] args)
        {
    #pragma warning disable 0612
            // This one is okay
            Foo("Good");
    #pragma warning restore 0612
            
            // This call is bad
            Foo("Bad");
        }
    }
