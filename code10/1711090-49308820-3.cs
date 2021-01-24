	public class SqlDatabaseThing
	{
	
		// ... additional code here ... //
	
		public static int ExecuteNonQuery(SqlCommand command, IEnumerable<SqlParameter> sqlParameters = new[]{}) =>
	    	ExecuteCommand(command, cmd => cmd.ExecuteNonQuery());
	
		public static T ExecuteScalar(SqlCommand command, IEnumerable<SqlParameter> sqlParameters = new[]{}) =>
		    ExecuteCommand(command, cmd => ConvertSqlCommandResult(cmd.ExecuteScalar()));
	
		public static DataTable ExecuteToDataTable(SqlCommand command, IEnumerable<SqlParameter> sqlParameters = new[]{}) =>
			ExecuteCommand(command, cmd => PopulateDataTable(cmd));
		
		private static T ExecuteCommand<T>(SqlCommand command, IEnumerable<SqlParameter> sqlParameters, Func<SqlCommand, T> resultRetriever)
		{
		    using (SqlConnection connection = new SqlConnection(_connStr))
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
