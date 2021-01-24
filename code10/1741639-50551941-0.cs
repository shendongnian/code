    class Example
    {
      public static int Value1 { get; set; } // Static property
    
      public int Value2 { get; set; } // Instance property
      
      public static string Hello() // Static method
      {
        return "Hello";
      }
      
      public string World() // Instance method
      {
        return " World";
      }
    }
    
    Console.WriteLine(Example.Hello() + new Example().World()); // "Hello World"
