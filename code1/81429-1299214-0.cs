     public interface IFoo
     {
         void Bar();
     }
     public class FooWrapper
     {
          private FrameworkFoo Foo { get; set; }
          public FooWrapper( FrameworkFoo foo )
          {
               this.Foo = foo;
          }
          public void Bar()
          {
               this.Foo.Bar();
          }
     }
