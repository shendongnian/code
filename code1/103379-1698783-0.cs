    public interface IViewModel<T>
    {
        void Map(T domainObject);
    }
    
    public class CarViewModel : IViewModel<Car>
    {
        public Map(Car domainObject) { ... }
    }
