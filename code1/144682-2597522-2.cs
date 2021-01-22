    var connString = ConfigurationManager.ConnectionStrings["MyConnectionStringName"].ConnectionString;
    DataTable newData;
    
    using ( var conn = new SqlConnection( connString ) )
    {
    	conn.Open();
    	const string sql = "Insert Foo(Name) Output inserted.Id, inserted.Name Values(@Name)";
    	using ( var cmd = new SqlCommand( sql, conn ) )
    	{
    		cmd.Parameters.AddWithValue("@Name", "bar");
    		using ( var da = new SqlDataAdapter( cmd ) )
    		{
    			da.Fill( newData );
    		}
    	}
    }
