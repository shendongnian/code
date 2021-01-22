    public int GetUsersCount(int userId)
    {
        using (var conn = new OracleConnection(...)){
    	    conn.Open();
    	    using(var command = conn.CreateCommand()){
    		    command.CommandText = "select count(*) from users where userid = :userId";
    		    command.AddParameter(":userId", userId);			
    		    var rowCount = command.ExecuteScalar();
    		    return rowCount == null ? 0 : Convert.ToInt32(rowCount);
    		}
    	}
    }
