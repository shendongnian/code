    using System;
    
    class Test
    {
        [Obsolete("Message")]
        static void Foo(string x)
        {
        }
        
        static void Main(string[] args)
        {
    #pragma warning disable 0618
            // This one is okay
            Foo("Good");
    #pragma warning restore 0618
            
            // This call is bad
            Foo("Bad");
        }
    }
