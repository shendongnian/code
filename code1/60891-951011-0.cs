    public class Product
    {
        private Manufacturer Manufacturer { get; private set;}
    }
    
    public class Manufacturer
    {
        private List<Product> Products { get; set; }
    }
