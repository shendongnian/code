    class MyClass
    {
      public int member = 123;
    }
    class Program
    {
      static void Main(string[] args)
      {
        MyClass obj = new MyClass();
    
        dynamic dynObj = obj;
        Console.WriteLine(dynObj.member);
    
        Console.ReadKey();
      }
    }
