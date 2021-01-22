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
    public class AnimalTamer<TAnimal> where TAnimal : Animal
    {
        IFactory<TAnimal> _animalFactory;
        public AnimalTamer(IFactory<TAnimal> animalFactory)
        {
            if(animalFactory == null)
            {
                throw new ArgumentNullException("animalFactory");
            }
            _animalFactory= animalFactory;
        }
        public void PutOnShow()
        {
            var animal = _animalFactory.Create();
            animal.MakeSound();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tamer = new AnimalTamer<Tiger>(new DefaultConstructorFactory<Tiger>());
            tamer.PutOnShow();
        }
    }
