    public interface ISuperFoo
    {
        ...
    }
    
    public abstract class SuperFoo<T> where T : ISuperFoo
    {
        public abstract T SomeMethod();
    }
    
    public class BazReturn : ISuperFoo
    {
        ...
    }
    
    public class Baz: SuperFoo<BazReturn>
    {
        public override BazReturn SomeMethod()
        {
            throw new NotImplementedException();
        }
    }
    
    public class BarReturn : ISuperFoo
    {
        ...
    }
    
    public class Bar : SuperFoo<BarReturn>
    {
        public override BarReturn SomeMethod()
        {
            throw new NotImplementedException();
        }
    }
    public static class EventHandler
    {
        public static void SomeEventHasHappened(List<SuperFoo<ISuperFoo>> list)
        {
            foreach (SuperFoo<ISuperFoo> item in list)
            {
                ISuperFoo result = item.SomeMethod();
            }
        }
    }
