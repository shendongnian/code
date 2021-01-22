    [Serializable]
    public class Product : IProduct
    {
         public Product(string name, double price)
         {
             this.Name = name;
             this.Price = price;
         }
         public string Name { get; private set; }
         public double Price { get; private set; }
    }
    ....
    [Web Method]
    [XmlInclude(typeof(Product))]
    Public double CalculateTotal(IProduct product, int quantity)
    {
         return product.Price * quantity;
    }
   
