    public class Product
    {
       ...
       public List<Category> Categories {get;set;}
    }
    public class Category
    {
       ...
       public int ProductId {get;set;}
       public Product Product {get;set;}
    }
    public class MyDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    using (MyDataContext db = new MyDataContext())
    {
        var categories = (from p in db.Products
                      join c in db.Categories
                      on p.CategoryId equals c.Id
                      select c).ToList();
         string productName = categories.First().Product.Name;
    
    }
