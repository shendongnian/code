    public interface IPizza
    {
        double CalculateCost();
    }
    public class Pizza : IPizza
    {
        private List<Topping> toppings = new List<Topping>();
        private double stdCost;
        
        public Pizza(double cost)
        {
            // this would be the standard cost of the pizza (before any toppings have been added)
            stdCost = cost;
        }
        public Pizza(IList<Topping> toppings)
        {
            this.toppings.AddRange(toppings);
        }
        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }
        public void RemoveTopping(Topping topping)
        {
            this.toppings.Remove(topping);
        }
        public double CalculateCost()
        {
            var total = stdCost;
            foreach (var t in toppings)
            {
                total += t.Price;
            }
            return total;
        }
    }
    public class Topping
    {
        public Topping(string description, double price)
        {
            Description = description;
            Price = price;
        }
        public double Price { get; private set; }
        public string Description { get; private set; }
    }
