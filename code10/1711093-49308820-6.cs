	public class SqlDatabaseThing //: ISqlDatabaseThing
	{
	
		// ... additional code here ... //
		public int ExecuteNonQuery(SqlCommand command, IEnumerable<SqlParameter> sqlParameters = new[]{}) =>
			ExecuteNonQuery(_connStr, command, sqlParameters);
		public static int ExecuteNonQuery(string connectionString, SqlCommand command, IEnumerable<SqlParameter> sqlParameters = new[]{}) =>
	    	ExecuteCommand(connectionString, command, cmd => cmd.ExecuteNonQuery());
	
		public T ExecuteScalar(SqlCommand command, IEnumerable<SqlParameter> sqlParameters = new[]{}) =>
			ExecuteScalar(_connStr, command, sqlParameters);
		public static T ExecuteScalar(string connectionString, SqlCommand command, IEnumerable<SqlParameter> sqlParameters = new[]{}) =>
		    ExecuteCommand(connectionString, command, cmd => ConvertSqlCommandResult(cmd.ExecuteScalar()));
	
		public DataTable ExecuteToDataTable(SqlCommand command, IEnumerable<SqlParameter> sqlParameters = new[]{}) =>
			ExecuteToDataTable(_connStr, command, sqlParameters);
		public static DataTable ExecuteToDataTable(string connectionString, SqlCommand command, IEnumerable<SqlParameter> sqlParameters = new[]{}) =>
			ExecuteCommand(connectionString, command, cmd => PopulateDataTable(cmd));
		
		private static T ExecuteCommand<T>(string connectionString, SqlCommand command, IEnumerable<SqlParameter> sqlParameters, Func<SqlCommand, T> resultRetriever)
		{
		    using (SqlConnection connection = new SqlConnection(connectionString))
		    {
				command.Parameters.AddRange(sqlParameters);
		        command.Connection = connection;
		        command.Connection.Open();
		        return resultRetriver(command);
		    }
		}
			
		private static DataTable PopulateDataTable(SqlCommand command)
		{
			var da = SqlDataAdapter(command);
			var dt = new DataTable();
			da.Fill(dt);
			return dt;
		}
		
		private static T ConvertSqlCommandResult(object result)
		{
			if (Convert.IsDbNull(result))
	            return default(T); 
	        if (result is T)
	            return result as T;
	        (T)Convert.ChangeType(result, typeof(T));
		}
		
	} 	
