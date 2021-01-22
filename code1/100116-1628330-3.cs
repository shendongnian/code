    using System;
    
    namespace Akadia.BasicDelegate
    {
        // Declaration
        public delegate void SimpleDelegate();
    
        class TestDelegate
        {
            public static void MyFunc()
            {
                Console.WriteLine("I was called by delegate ...");
            }
    
            public static void Main()
            {
                // Instantiation-- we set this simpleDelegate to MyFunc
                SimpleDelegate simpleDelegate = new SimpleDelegate(MyFunc);
    
                // Invocation-- MyFunc is called. 
                simpleDelegate();
            }
        }
    }
