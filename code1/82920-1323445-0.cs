    public class Product
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public int Quantity { get; set; }
      public Product()
      {
          this.Id = 0;
          this.Name = null;
          this.Quantity = 0;
      }
      public Product(Product product)
      {
          this.Id = product.id;
          this.Name = product.Name;
          this.Quantity = product.Quantity;
      }
    }
    IList<Product> myProducts = new List<Product>();
    Product product1 = new Product() { Id = 0, Name = "Buzz Cola" };
    Product product2 = new Product() { Id = 1, Name = "Choco Bites" };
    Product product3 = new Product(product1); // Use copy-constructor.
    myProducts.Add(product1);
    myProducts.Add(product2);
    myProducts.Add(product3);
    myProducts[0].Quantity = 1;
