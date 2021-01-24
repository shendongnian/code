    public class Customer
    {
        public int Id { get; set; }
        public int? CurrentApplicationId { get; set; }
        public Application CurrentApplication { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
    public class Application
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
    }
