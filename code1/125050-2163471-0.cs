    class Users
    {
      private Tags tags;
      private Products products;
    }
    
    class Tags : IList<Tag> {}
    class Tag
    {
      private Products products;
      public void AddProduct(Product product);
    }
    
    class Products : IList<Product> {}
    class Product
    {
      private Tags tags;
      public void AddTag(Tag tag);
    }
