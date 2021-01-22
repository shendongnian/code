    using System;
    class Test
    {
        public static void Main()
        {
            string test = "before passing";
            Console.WriteLine(test);
            TestI(ref test);
            Console.WriteLine(test);
        }
    
        public static void TestI(ref string test)
        {
            test = "after passing";
        }
    }
