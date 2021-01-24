    public class Customer
    {
         public int Id { get; set; }
    
         public ICollection<Order> Orders { get; set; }
    }
    
    public class Order
    {
         public int Id { get; set; }
         ...
    
         public int CustomerId { get; set; }
    
         [ForeignKey("CustomerId")]
         public Customer Customer{ get; set; }
    }
