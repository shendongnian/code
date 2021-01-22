    public abstract class MyBaseClass
    {
      public virtual void Foo()
      {
        Console.WriteLine("MyBaseClass.Foo");
      }
    
      public virtual void Bar()
      {
        throw new NotImplementedException();
      }
    }
    
    public class MyClass : MyBaseClass
    {
      public override void Foo()
      {
        Console.WriteLine("MyClass.Foo");
      }
    }
