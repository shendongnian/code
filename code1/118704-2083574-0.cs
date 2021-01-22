    public class Product
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual bool Visible { get; set; }
        public virtual IList<Category> Categories { get; set; }
        public Product()
        {
            Categories = new List<Category>();
        }
    }
    public class ProductMap : ClassMap<Product>
    {
        Id(x => x.Id);
        Map(x => x.Name);
        Map(x => x.Description);
        Map(x => x.Price);
        Map(x => x.Visible);
        HasManyToMany(x => x.Categories)
          .Table("ProductsToCategories")
          .ParentKeyColumn("Product_id")
          .ChildKeyColumn("Category_id")
          .Cascade.AllDeleteOrphan();
    }
    public class Category
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Visible { get; set; }
        public virtual IList<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
    public class CategoryMap : ClassMap<Category>
    {
        Id(x => x.Id);
        Map(x => x.Name);
        Map(x => x.Description);
        Map(x => x.Visible);
        HasManyToMany(x => x.Products)
          .Table("ProductsToCategories")
          .ParentKeyColumn("Category_id")
          .ChildKeyColumn("Product_id")
          .Cascade.AllDeleteOrphan().Inverse();
    }
