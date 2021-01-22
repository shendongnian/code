    using System;
    
    namespace Test
    {
        public class X
        {
            public String Bleh;
        }
    
        public class Y : X
        {
            public String Blah;
        }
    
        public static class Program
        {
            public static void Main()
            {
                var y = SomeFunctionThatReturnsY();
                // y. <-- this gives me both Blah and Bleh in the dropdown
            }
    
            public static Y SomeFunctionThatReturnsY()
            {
                return new Y();
            }
        }
    }
