    using System;
    
    namespace MyProg
    {
      class Program
      {
    
        private static void ParamTest(params object[] args)
        {
          foreach (object o in args)
          {
            Console.Write(o);
            Console.WriteLine(", ");
          }
          Console.WriteLine();
        }
    
        static void Main(string[] args)
        {
          ParamTest(1, "abc", 2.4, new object());
        }
      }
    }
