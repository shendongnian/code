`c#
   // Binding
   public sealed class FooModule: NinjectModule 
   {
     public opverride void Load() 
     {
        Bind<IReadOnlyList<IFoo>>().ToConstant(new IFoo[0]);
      }
   }
   // Injection target
   public class InjectedClass {
      public InjectedClass(IReadOnlyList<IFoo> foos) { ;}
   }
`
