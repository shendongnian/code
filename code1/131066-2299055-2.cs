    public abstract class Foo
    {
         public string Name { get; private set; }
         protected Foo( string name )
         {
             this.Name = name;
         }
    }
    public class Bar : Foo
    {
         public Bar() : base("bar")
         {
            ...
         }
    }
