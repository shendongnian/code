    public interface ISpecification<T>
    {
      bool Matches(T instance);
      string GetSql();
    }
    public class ProductCategoryNameSpecification : ISpecification<Product>
    {
      readonly string CategoryName;
      public ProductCategoryNameSpecification(string categoryName)
      {
        CategoryName = categoryName;
      }
    
      public bool Matches(Product instance)
      {
        return instance.Category.Name == CategoryName;
      }
    
      public string GetSql()
      {
        return "CategoryName like '" + { escaped CategoryName } + "'";
      }
    }
