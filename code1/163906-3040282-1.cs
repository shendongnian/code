    public class ProductExtraModel
    {
       //Database 
      public int ID { get; set; }
      public string Name { get; set; }
      [UIHint("Product")]
      public ProductModel Product { get; set; }
    }
