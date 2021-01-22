    private string GetSql( IList<int> machineIds )
    {
    	var sql = new StringBuilder( "SELECT FileID FROM Files Where MachineID In(" );
    	for( var i = 0; i < machineIds.Count; i++ )
    	{
    		if ( i > 0 )
    			sql.Append(", ")
    		sql.Append("@MachineId{0}", i);
    	}
    
    	sql.Append(" ) ");
    	return sql.ToString();
    }
    
    private DataTable GetData( IList<int> machineIds )
    {
    	var dt = new DataTable();
    	var sql = GetSql( machineIds );
    	using ( var conn = new SqlConnection() )
    	{
    		conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
    		using ( var cmd = new SqlCommand( sql, conn ) )
    		{
    			conn.Open();
    			
    			for( var i = 0; i < machineIds.Count; i++ )
    			{
    				var parameterName = string.Format("@MachineId{0}", i );
    				sqlCmd.Parameters.AddWithValue( parameterName, machineIds[i] );
    			}
    			
    			using ( var da = new SqlDataAdapter( cmd ) )
    			{
    				da.Fill( dt );
    			}
    		}
    	}
    	
    	return dt;
    }
