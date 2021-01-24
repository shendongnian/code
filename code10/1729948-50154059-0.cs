    public interface ISingleton<T>
    {}
    
    public interface IEagerSingleton
    {}
    public class Singleton : IEagerSingleton
    {
        
    }
    //In a startup method somewhere
    var collection = new
    ServiceCollection().AddSingletonsFromAssembly(typeof(IEagerSingleton));
    collection.AddSingletonsFromAssembly(typeof(ISingleton<>));
    
    var provider = collection.BuildServiceProvider();
    provider.GetServices<IEagerSingleton>();
