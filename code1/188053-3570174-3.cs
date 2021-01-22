    class Base
    {
       public virtual void DoStuff() { Console.WriteLine("Base"); }
    }
    
    class Foo : Base
    {
       public override void DoStuff() { Console.WriteLine("Foo");  }
    }
