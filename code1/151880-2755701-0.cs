    var connString = ...
    using ( var conn = new SqlConnection( connString ) )
    {
    	using ( var cmd = new SqlCommand( "exec sp_rename 'Table_1', 'Table_2'", conn ) )
    	{
    		conn.Open();
    		cmd.ExecuteNonQuery();
    	}
    }
