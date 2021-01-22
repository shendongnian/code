    // Comment this line to exclude method with Conditional attribute
    #define PHASE_1
    using System;
    using System.Diagnostics;
    class Program {
        [Conditional("PHASE_1")]
        public static void DoSomething(string s) {
            Console.WriteLine(s);
        }
        public static void Main() {
            DoSomething("Hello World");
        }
    }
