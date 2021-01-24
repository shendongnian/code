        public class Suace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<Idgredient> Idgredients { get; set; }
        public Sauce Sauce {get;set;}
    
        public virtual ICollection<Order> Orders { get; set; }
    }
    class Order
    {
        public Order()
        {
            Cars = new List<Car>();
            Parts = new List<Part>();
        }
    
        public int OrderId { get; set; }
    
        public virtual ICollection<Car> Suace  { get; set; }
        public virtual ICollection<Part> Pizza { get; set; }
    }
    public class Idgredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
    
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
