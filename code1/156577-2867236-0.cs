    public class FactoryMap { 
      private Dictionary<Type,object> _map = new Dictionary<Type,object>();
      public void Add<T>(IFactory<T> factory) {
        _map[typeof(T)] = factory;
      }
      public IFactory<T> Get<T>() {
        return (IFactory<T>)_map[typeof(T)];
      }
    }
