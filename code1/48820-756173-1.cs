    using System;
    using System.Collections.Generic;
    
    namespace TestParam222
    {
      class Program
      {
        static void Main(string[] args)
        {
          Console.WriteLine("The total is {0}.", Tools.GetTest(param => 23));
          Console.ReadLine();
        }
      }
    
      class Tools
      {
        public static string GetTest(Func<int, int> integers)
        {
          return "ok";
        }
      }
    }
