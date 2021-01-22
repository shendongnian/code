	interface IProduct
	{
		string Id { get; }
		string Description { get; }
	}
	
	class ProductDB
	{
		public void SaveProduct(IProduct product)
		{
			...
		}
	}
