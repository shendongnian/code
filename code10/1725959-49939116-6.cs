    using System;
    
    public class Test
    {
        static void Main()
        {
            // Valid
            Action t1 = () => { while(true); };
            
            // Valid: end of lambda is unreachable, so it's fine to say
            // it'll return an int when it gets to that end point.
            Func<int> t2 = () => { while(true); };
            
            // Valid
            Action t3 = () => { while(false); };
            
            // Invalid
            Func<int> t4 = () => { while(false); };
        }
    }
