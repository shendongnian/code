    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = AnimalFactory.CreateAnimal<Dog>();
            animal.Speak();
            Console.ReadKey();
        }
    }
    public abstract class AnimalFactory
    {
        public static IAnimal CreateAnimal<T>() where T : IAnimal, new()
        {
            return new T();
        }
    }
    public interface IAnimal
    {
        void Speak();
    }
    public class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Woof");
        }
    }
    public class Cat : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Meow");
        }
    }
