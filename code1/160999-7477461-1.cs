    public virtual DataTable ExecuteDataTable(SqlCommand command, params SqlParameter[] parameters)
    {
	    command.Parameters.AddRange(parameters);
	    DataTable table = new DataTable();
	    using (SqlDataAdapter adapter = new SqlDataAdapter(command)) {
		    using (command) {
			    ExecuteAndLogError(() => adapter.Fill(table), command.CommandText, command.Parameters);
		    }
	    }
	    return table;
