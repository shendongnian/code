    public class Product
    {
      public Product()
      {
         OrderDetails = new HashSet<OrderDetail>();
      }
      (...)
      public ICollection<OrderDetail> OrderDetails { get; set; }
    }
