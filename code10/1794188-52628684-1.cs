	public sealed class SomeRepository
	{
		private readonly string connectionString;
		public SomeRepository()
		{
		  // the ideal location for a connection string is in the application's app.config (or web.confic)
		  connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
		  
		  // Or uncomment this
		  // connectionString = "Server=SQLOLEDB.1;User ID=" +
			//		Constants.DATABASE_USERNAME + ";Password=" +
			//		Constants.DATABASE_PASSWORD + ";Initial Catalog=" +
			//		Constants.DATABASE_CATALOG + ";Data Source=" +
			//		Constants.SERVER_ADRESS;
		}
		
		public string GetUserName(int id)
		{
			const string sqlRequest = "SELECT Name FROM Names WHERE ID = @id";
			
			using (SqlConnection conn = new SqlConnection(this.connectionString))
			using (SqlCommand command = new SqlCommand(sqlRequest, conn))
			{
				// if this is an integer in the schema, which it looks like it should be, then you need to pass it as an int and not a string
				command.Parameters.Add("@id", SqlDbType.Int).Value = id;
				
				// if it is a string then specify the type as varchar and specify the varchar length in the schema and pass a string
				// command.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id.ToString();
				
				conn.Open();
				return command.ExecuteScalar()?.ToString();
			}
		}
	}
