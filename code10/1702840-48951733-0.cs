	public class Variation
	{
		public int Id { get; set; }
		[JsonProperty(PropertyName = "stock_quantity")]
		public int StockQuantity { get; set; }
		public string Sku { get; set; }
		public decimal Price { get; set; }
	}
  
	public class Product
	{
		public string Title { get; set; }
		public int Id { get; set; }
		[JsonProperty(PropertyName = "short_description")]
		public string ShortDescription { get; set; }
		public List<Variation> Variations { get; set; }
	}
  
	public class ProductCollection
	{
		List<Product> Products { get; set; }
	}
