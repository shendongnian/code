    public class MyBase
    {
      public MyBase()
      {
        Console.WriteLine("MyBase");
      }
    }
    
    public class MyDerived : MyBase
    {
      public MyDerived():base()
      {
        Console.WriteLine("MyDerived");
      }
    }
