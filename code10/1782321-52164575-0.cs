    public class Customer
    {
         public int CustomerId { get; set; }
         [Index("IX_Customer_Key", 1, IsUnique = true)]
         public Guid CustomerKey { get; set; }
    
         public ICollection<Product> Products { get; set; }
    }
    
    public class Product
    {
         public int ProductId { get; set; }
         public Guid CustomerKey { get; set; }
         public string Name { get; set; }
         
         [ForeignKey("CustomerKey")]
         public Customer Customer{ get; set; }
    }
