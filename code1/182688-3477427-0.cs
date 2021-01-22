    using System;
    using System.Diagnostics;
    
    class Test
    {
        [Conditional("FOO")]
        static void CallMe()
        {
            Console.WriteLine("Called");
        }
        
        static void Main()
        {
            CallMe();
        }
    }
