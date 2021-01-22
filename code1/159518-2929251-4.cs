	public class Product
	{
		public int    ProductID   { get; private set; }
		public string ProductName { get; private set; }
		public int    Qty         { get; set; }
		
		public Product( int productID, string productName, int total )
		{
			this.ProductID = productID;
			this.ProductName = productName;
			this.Qty = total;
		}		
	}
