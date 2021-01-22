    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(AllTypes.Pick().FromAssembly(Assembly.GetExecutingAssembly()).AllowMultipleMatches());
            var dog = container.Resolve<Dog>();
            var animals = container.ResolveAll<IAnimal>();
        }
    }
    public interface IAnimal
    {
    }
    public class Dog : IAnimal
    {
    }
    public class Cat : IAnimal
    {
    }
    public class Fish : IAnimal
    {
    }
