	public class DbDataReader
	{
		string connectionString = @"....";
		public async Task<IEnumerable<Product>> GetProducts()
		{
			using(var connection = await GetOpenConnection())
			{
				var products = await connection.QueryAsync<Product>("select * from Products;WAITFOR DELAY '00:00:05'");
				return products.Where(p => p.Active);
			}
		}
		private async Task<SqlConnection> GetOpenConnection()
		{
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			await sqlConnection.OpenAsync();
			return sqlConnection;
		}
	}
