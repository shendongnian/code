    using System;
    using System.Text;
    class Test
    {
        public static void Main()
        {
            StringBuilder test = new StringBuilder();
            Console.WriteLine(test);
            TestI(test);
            Console.WriteLine(test);
        }
    
        public static void TestI(StringBuilder test)
        {
            // Note that we're not changing the value
            // of the "test" parameter - we're changing
            // the data in the object it's referring to
            test.Append("changing");
        }
    }
