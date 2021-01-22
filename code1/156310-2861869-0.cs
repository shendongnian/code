    enum QueryType {AQuery, BQuery};
    private SqlDataReader DoQuery(QueryType _type)
    {
    	using (SqlConnection conn = new SqlConnection("your connection string"))
    	{
    		using (SqlCommand cmd = conn.CreateCommand())
    		{
    			switch(_type)
    			{
    				case QueryType.AQuery:
    					cmd.CommandText = @"SELECT thing FROM table";
    					break;
    				case QueryType.BQuery:
    					cmd.CommandText = @"SELECT other_thing FROM table";
    					break;
    			}
    			conn.Open();
    			SqlDataReader reader = cmd.ExecuteReader();
    			//...
    		}
    	}
    }
