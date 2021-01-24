	public class ProductRepository : BaseRepository<Product>
	{
		protected override async Task QueryAndPopulateDataAsync(ListReturnDTO<TEntity> container)
		{
            container.TotalItem = 11;
            ........
            container.data.Add(new Product { SKU = "000006", Description = "this is the test product 7, a rare breed of product", Price = 65.00, QuantityLeft = 3, Title = "Test Product 7", IsPreview = false });
            container.data.Add(new Product { SKU = "000007", Description = "this is the test product 8, a rare breed of product", Price = 7.00, QuantityLeft = 30, Title = "Test Product 8", IsPreview = false });
            //force a delay to replicate talking to external source
            Thread.Sleep(2000);
		}
	}
