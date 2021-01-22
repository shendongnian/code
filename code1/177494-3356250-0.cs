    public abstract class Factory<T>
    {
        public abstract T GetInstance();
    }
    public sealed class IoCFactory<T, TDerived> : Factory<T>
        where TDerived : T // compiler enforces that TDerived derives from T
    {
        public override T GetInstance()
        {
            // TODO: retrieve instance of TDerived from IoC container such as Spring.NET, StructureMap, Unity, etc.
            throw new NotImplementedException();
        }
    }
    public sealed class ActivatorFactory<T, TDerived> : Factory<T>
        where TDerived : T, new() // compiler enforces that TDerived derives from T and that it has a parameterless constructor
    {
        public override T GetInstance()
        {
            return Activator.CreateInstance<TDerived>();
        }
    }
    public class BarHandler
    {
        public Factory<Foo> fooFactory { get; set; }
        public ProcessedBar Process(string xml)
        {
            Foo foo = fooFactory.GetInstance();
            return foo.Process(xml);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BarHandler handler = new BarHandler();
            handler.fooFactory = new ActivatorFactory<Foo, Bar>();
            var processedResult = handler.Process("<bar>Yar!</bar>");
        }
    }
