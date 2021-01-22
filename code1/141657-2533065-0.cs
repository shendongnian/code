    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1 {
      class Program {
        static void Main(string[] args) {
          Process.Start("ConsoleApplication2.exe");
        }
      }
    }
----------
    using System;
    using System.IO;
    
    namespace ConsoleApplication2 {
      class Program {
        static void Main(string[] args) {
          try {
            File.WriteAllText(@"c:\program files\test.txt", "hello world");
          }
          catch (Exception ex) {
            Console.WriteLine(ex.ToString());
            Console.ReadLine();
          }
        }
      }
    }
