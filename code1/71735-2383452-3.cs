    public static class Bootstrapper 
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(
             x => x.AddRegistry(new MyApplicationRegistry()));            
        }
    }
    
    public class MyApplicationRegistry : Registry
    {
        public MyApplicationRegistry()
        {
             ForRequestedType<ISomeService>()
             .TheDefault.Is.OfConcreteType<SomeService>();
        }
    }
