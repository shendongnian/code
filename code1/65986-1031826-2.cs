    using System;
    
    class TestClass {
        public static T Test<T>() {
            return TestWith(default(T));
            // do something else
        }
    
        public static string TestWith(string dummy) {
            // Used only for `string`.
            return "string";
        }
    
        public static T TestWith<T>(T dummy) {
            // Used for everything else.
            return dummy;
        }
    
        static void Main() {
            Console.WriteLine("Expected \"0\", got \"{0}\"", Test<int>());
            Console.WriteLine("Expected \"string\", got \"{0}\"", Test<string>());
        }
    }
