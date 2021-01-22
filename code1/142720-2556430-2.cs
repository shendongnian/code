    internal void UpdateCash(CashUpdateQuery query)
    {
    	using(OurCustomDbConnection conn = CreateConnection("UpdateCash"))
    	{
    		query.SetConnectionProperties(conn);
    		conn.ExecuteNonQuery();
    	}
    }
