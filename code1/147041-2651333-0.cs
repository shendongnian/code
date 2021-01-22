    public interface IPizza
    {
        decimal Price { get; }
    }
     
    public class HamAndMushroomPizza : IPizza
    {
        decimal IPizza.Price
        {
            get
            {
                return 8.5m;
            }
        }
    }
     
    public class DeluxePizza : IPizza
    {
        decimal IPizza.Price
        {
            get
            {
                return 10.5m;
            }
        }
    }
     
    public class HawaiianPizza : IPizza
    {
        decimal IPizza.Price
        {
            get
            {
                return 11.5m;
            }
        }
    }
     
    public class PizzaFactory
    {
        public enum PizzaType
        {
            HamMushroom,
            Deluxe,
            Hawaiian
        }
     
        public static IPizza CreatePizza(PizzaType pizzaType)
        {
            IPizza ret = null;
     
            switch (pizzaType)
            {
                case PizzaType.HamMushroom:
                    ret = new HamAndMushroomPizza();
     
                    break;
                case PizzaType.Deluxe:
                    ret = new DeluxePizza();
     
                    break;
                case PizzaType.Hawaiian:
                    ret = new HawaiianPizza();
     
                    break;
                default:
                    throw new ArgumentException("The pizza type " + pizzaType + " is not recognized.");
            }
     
            return ret;
        }
    }
     
    public class PizzaLover
    {
        public static void Main(string[] args)
        {
            Dictionary<PizzaFactory.PizzaType, IPizza> pizzas = new Dictionary<PizzaFactory.PizzaType, IPizza>();
     
            foreach (PizzaFactory.PizzaType pizzaType in Enum.GetValues(typeof(PizzaFactory.PizzaType)))
            {
                pizzas.Add(pizzaType, PizzaFactory.CreatePizza(pizzaType));
            }
     
            foreach (PizzaFactory.PizzaType pizzaType in pizzas.Keys)
            {
                System.Console.WriteLine("Price of {0} is {1}", pizzaType, pizzas[pizzaType].Price);
            }
        }
    }
     
    Output:
    Price of HamMushroom is 8.5
    Price of Deluxe is 10.5
    Price of Hawaiian is 11.5
