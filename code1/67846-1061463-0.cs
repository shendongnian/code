	void Main()
	{
		ProductList products = new ProductList();
		products.Add(new Product("foo"));
		products.Add(new Product("bar"));
		foreach(Product p in products)
		{
			Console.WriteLine(p.Name);
		}
	}
	// Define other methods and classes here
	public class ProductList : List<Product>
	{ /* [snip] the other stuff is irrelevant */ }
	public class Product 
	{
		public Product(string name)
		{ Name = name; }
		public string Name;
	}
