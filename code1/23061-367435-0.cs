    public interface IFactory<T>
    {
        T Create();
    }
    public class DefaultConstructorFactory<T> : IFactory<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }
    public class ActivatorFactory<T> : IFactory<T>
    {
        public T Create()
        {
            return Activator.CreateInstance<T>();
        }
    }
    public class AnimalTamer
    {
        IFactory<Animal> _factory;
        public AnimalTamer(IFactory<Animal> factory)
        {
            if(factory == null)
            {
                throw new ArgumentNullException("factory");
            }
            _factory = factory;
        }
        public void PutOnShow()
        {
            var animal = _factory.Create();
            animal.MakeSound();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tamer = new AnimalTamer(new DefaultConstructorFactory<Tiger>());
            tamer.PutOnShow();
        }
    }
