    using System;
    
    class MainClass {
        public static void Main (string[] args) {
  
            Console.WriteLine(new Test().c);
            Console.WriteLine(new Test("Constructor").c);
            Console.WriteLine(new Test().ChangeC()); //Error A readonly field 
            // `MainClass.Test.c' cannot be assigned to (except in a constructor or a 
            // variable initializer)
        }
        public class Test {
            public readonly string c = "Hello World";
            public Test() {
      
            }
            public Test(string val) {
              c = val;
            }
    
            public string ChangeC() {
                c = "Method";
                return c ;
            }
        }
    }
