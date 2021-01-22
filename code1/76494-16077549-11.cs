	public class Product
	{
		[Key]
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public Decimal? UnitPrice { get; set; }
		public bool Discontinued { get; set; }
		public virtual Category category { get; set; }
	}
	// class Category omitted in this example
	public class Northwind : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
