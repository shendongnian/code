    public static class Program
    {
      public static IConsole Console { get; set; }
      // method that does the "logic"
      public static void HelloWorld()
      {
        Console.WriteLine("Hello World");
      }
    
      // setup real environment
      public static void Main()
      {
        Console = new RealConsoleImplementation();
        HelloWorld();
      }
    }
