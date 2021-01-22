    using System;
    
    class Program
    {
        static void Main()
        {
            MethodA();
        }
    
        [Obsolete("Use MethodB instead")]
        static void MethodA()
        {
        }
        static void MethodB()
        {
        }
    }
