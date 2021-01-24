    using System;
    
    public class Test
    {
        static void Main()
        {
            // Valid
            Action t1 = () => { while(true); };
            
            // Valid
            Func<int> t2 = () => { while(true); };
            
            // Valid
            Action t3 = () => { while(false); };
            
            // Invalid
            Func<int> t4 = () => { while(false); };
        }
    }
