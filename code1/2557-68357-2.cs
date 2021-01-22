    public interface IFactory
    {
        IInterface Create();
    }
    public class Factory<T> where T : IInterface, new()
    {
        public IInterface Create() { return new T(); }
    }
    public IInterface CreateUsingFactory(IFactory factory)
    {
        return factory.Create();
    }
    public void Test()
    {
        IInterface thing = CreateUsingFactory(new Factory<Foo>());
    }
