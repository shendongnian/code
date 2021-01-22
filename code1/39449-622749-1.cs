    using System;
    using System.Diagnostics;
    
    class Test
    {
        static void Main()
        {
            int i ;
            MethodWithOut(out x);
        }
        
        [Conditional("FOO")]
        static void MethodWithOut(out int x)
        {
            x = 10;
        }
    }
