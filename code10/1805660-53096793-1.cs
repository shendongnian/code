	public class DbDataReader
	{
		public async Task<IEnumerable<Product>> GetProducts()
		{
			string connectionString = @"....";
			using(var connection = new SqlConnection(connectionString))
			{
				var products = await connection.QueryAsync<Product>("select * from Products");
				return products.Where(p => p.Active);
			}
		}
	}
