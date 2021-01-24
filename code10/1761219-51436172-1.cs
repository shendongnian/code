        using System.Data;
        using System.Data.Common;
        using System.Data.SqlClient;
    
        namespace MyProject.DAL
        {
    	public class SQLDataAccess
    	{
    	
    		protected string ConnectionString { get; set; }
    
    		public SQLDataAccess()
    		{
    			var configuration = new ConfigurationBuilder()
    				.SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()) + "/MyProject.DAL").AddJsonFile("config.json", false)
    				.Build();
    
    			this.ConnectionString = configuration.GetSection("connectionString").Value;
    		}
    
    		private SqlConnection GetConnection()
    		{
    			SqlConnection connection = new SqlConnection(this.ConnectionString);
    			if (connection.State != ConnectionState.Open)
    				connection.Open();
    			return connection;
    		}
    
    		public DbDataReader GetDataReader(string procedureName, List<SqlParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
    		{
    			DbDataReader dr;
    
    			try
    			{
    				DbConnection connection = this.GetConnection();
    				{
    					DbCommand cmd = this.GetCommand(connection, procedureName, commandType);
    					if (parameters != null && parameters.Count > 0)
    					{
    						cmd.Parameters.AddRange(parameters.ToArray());
    					}
    
    					dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    				}
    			}
    			catch (Exception ex)
    			{
    				throw;
    			}
    
    			return dr;
    		}
    	}
         }
