    // Base class
    public class Base
    {
      protected string prefix;
      public Base()
      {
        Initialize();
        Console.WriteLine(prefix);
      }  
      
      protected virtual void Initialize()
      {
        prefix = "Primary";
      }
    }
    // Inheriting class
    public class Child : Base
    {
      public override void Initialize()
      {
        prefix = "Secondary";
      }
    }
