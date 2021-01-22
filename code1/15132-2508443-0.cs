    using System;
    using System.Dynamic;
    static class DyanmicDemo
    {
        public static void Main() {
      for(Int32 demo =0; demo < 2; demo++) {
       dynamic arg = (demo == 0) ? (dynamic) 5 : (dynamic) "A";
       dynamic result = Plus(arg);
       M(result);
      }
     }
        private static dynamic Plus(dynamic arg) { return arg + arg; }
        private static void M(Int32 n) { Console.WriteLine("M(Int32): " + n); }
        private static void M(String s) { Console.WriteLine("M(String): " + s); }
    }
