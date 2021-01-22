	public class Product
	{
		private int ProductID;
		private string ProductName;
		private int Qty;
		
		public Product( int productID, string productName, int total )
		{
			this.ProductID = productID;
			this.ProductName = productName;
			this.Qty = total;
		}
		
		public int GetQty()
		{
			return Qty;
		}
	}
