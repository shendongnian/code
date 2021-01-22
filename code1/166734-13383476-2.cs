    public interface IFoo { }
    public class FooA : IFoo {}
    public class FooB : IFoo {}
    public class Bar
    {
        //array injected will contain [ FooA, FooB ] 
        public Bar(IFoo[] foos) { }
    }
    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFoo>().To<FooA>();
            Bind<IFoo>().To<FooB>();
            //etc..
        }
    }
