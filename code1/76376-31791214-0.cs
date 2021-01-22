    public void storedProcedureName(Nullable<int> id, string name)
    {
    	var idParameter = id.HasValue ?
    				new SqlParameter("Id", id) :
    				new SqlParameter { ParameterName = "Id", SqlDbType = SqlDbType.Int, Value = DBNull.Value };
    
        // to be continued...
