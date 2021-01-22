    public class OrderViewModel
    {
    public int OrderId{ get; set; }
    public IEnumerable<Product> Products{ get; set; }
    
    public class Product {
    public string ProductName{ get; set; }
    public decimal ProductPrice{ get; set; }
    }
    
    }
