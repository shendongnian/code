	void Main()
	{
		var catalogue = 
			new List<ProductCategory>
			{
				new ProductCategory { Title = "1", Products = new List<Product> { new Product { Name = "A" }, new Product { Name = "B" }, new Product { Name = "C" }, } },
				new ProductCategory { Title = "2", Products = new List<Product> { new Product { Name = "A" }, new Product { Name = "B" }, new Product { Name = "C" }, } },
				new ProductCategory { Title = "3", Products = new List<Product> { new Product { Name = "A" }, new Product { Name = "B" }, new Product { Name = "C" }, } },
				new ProductCategory { Title = "4", Products = new List<Product> { new Product { Name = "A" }, new Product { Name = "B" }, new Product { Name = "C" }, } },
			};
	
		var allEqual = catalogue
			.Skip(1)
			.Zip(catalogue, (x, y) => x.Products.SequenceEqual(y.Products, new ProductComparer()))
			.All(c => c);
	
		Console.WriteLine($"This is equal: {allEqual}");
	}
	
	public class ProductCategory
	{
		public String Title { get; set; }
		public List<Product> Products { get; set; }
	}
	
	public class Product
	{
		public String Name { get; set; }
	}
	
	public class ProductComparer : IEqualityComparer<Product>
	{
		public bool Equals(Product x, Product y)
		{
			if (Object.ReferenceEquals(x, y))
			{
				return true;
			}
	
			if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
			{
				return false;
			}
			
			return x.Name == y.Name;
		}
	
		public int GetHashCode(Product product)
		{
			if (Object.ReferenceEquals(product, null))
			{
				return 0;
			}
	
			int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();
	
			return hashProductName;
		}
	}
