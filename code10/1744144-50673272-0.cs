    using System;
    namespace ConsoleApp3
    {
      class Program
      {
          static Program()
          {
              Console.WriteLine("static ctor of Program");
          }
          static void Main(string[] args)
          {
              Console.WriteLine("Main");
          }
      }
      public static class ModuleInitializer
      {
          public static void Initialize()
          {
              Console.WriteLine("Module Initializer");
          }
      }
    }
