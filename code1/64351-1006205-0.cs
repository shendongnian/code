    public interface ICanCreate<out T> // covariant
    {
        T NewObject();
    }
    public class Factory
    {
        private Dictionary<Type, ICanCreate<object>> mappings = new Dictionary<Type, ICanCreate<object>>();
    
        public void RegisterCreator<T>(ICanCreate<T> creator) where T:class
        {            
          mappings[typeof(T)] = creator;
        }
    
        public T Create<T>()
        {            
          ICanCreate<object> creator = mappings[typeof(T)];
          return (T) creator.NewObject(); // I do not think you can get rid of this cast
        }
    }
