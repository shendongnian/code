    public static IEnumerable<Product> ByName(this IEnumerable<Product> products, string description)
	{
		return products.Where(p => p.Description.Contains(description));
	}
	
	
	public static IEnumerable<Product> AreDiscontinued(IEnumerable<Product> products, bool isDiscontinued)
	{
		return products.Where(p => p.Discontinued == discontinued);
	}
