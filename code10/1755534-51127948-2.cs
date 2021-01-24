    public class Order
    {
       public int OrderID {get;set;}
       public string OrderName {get;set;}
       public ICollection<OrderProduct> Products { get; set; } = new HashSet<OrderProduct>();
    }
    
    public class Product
    {
       public int ProductID {get;set;}
       public string ProductName {get;set;}
       public ICollection<OrderProduct> Orders { get; set; } = new HashSet<OrderProduct>();
    }
