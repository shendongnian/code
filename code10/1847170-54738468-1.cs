    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    
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
    
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
