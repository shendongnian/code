    public class Product
    {
       public string Name;
       public string Color;
       public string Category;
    
       public Product(Product o)
       {
          this.Name=o.Name;
          this.Color=o.Color;
          this.Category=o.Category;
       } 
       // Note we need to give a default constructor when override it
    
       public Product()
       {
       }
    } 
    public Product Produce(Product sample)
    {
       Product p=new Product(sample);
       p.Category="Finished Product";
       return p;
    }
    Product sample=new Product();
    sample.Name="Toy";
    sample.Color="Red";
    sample.Category="Sample Product";
    Product p=Produce(sample);
    Console.WriteLine(String.Format("Product: Name={0}, Color={1}, Category={2}", p.Name, p.Color, p.Category));
    Console.WriteLine(String.Format("Sample: Name={0}, Color={1}, Category={2}", sample.Name, sample.Color, sample.Category));
