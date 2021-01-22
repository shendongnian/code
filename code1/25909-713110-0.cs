    class Program
    {
      public static readonly Test test = new Test();
      static void Main(string[] args)
      {
         test.Name = "Program";
         test = new Test(); // Error: A static readonly field cannot be assigned to (except in a static constructor or a variable initializer)
      }
    }
    class Test
    {
       public string Name;
    }
