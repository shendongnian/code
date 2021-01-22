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
             .CacheBy(InstanceScope.Your_Choice_Here)
             .TheDefault.Is.OfConcreteType<SomeService>();
        }
    }
