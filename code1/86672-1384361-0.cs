    public interface IDrink{}
    public interface IEat{}
    
    public class Milk : IDrink{}
    public class Water: IDrink  {}
    public class Potato : IEat { }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            object milk = new Milk();
            Console.WriteLine("Is Milk an IDrink: {0}",
                typeof(IDrink).IsInstanceOfType(milk));
            Console.WriteLine("Is Milk an IEat: {0}",
                typeof(IEat).IsInstanceOfType(milk));
    
            Console.ReadLine();
        }
    }
