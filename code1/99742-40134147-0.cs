    using (var tx = new TransactionScope())
    {
    	using (var con = new SqlConnection($"{connectionstring}"))
    	{
    		con.Open();
    
    		using (var com = new SqlCommand($"set xact_abort on; begin transaction; INSERT INTO dbo.KeyValueTable VALUES ('value1', '{Guid.NewGuid()}'); rollback;", con))
    		{
    			// This transaction failed, but it doesn't rollback the entire system.transaction!
    			com.ExecuteNonQuery();
    		}
    
    		using (var com = new SqlCommand($"set xact_abort on; begin transaction; INSERT INTO dbo.KeyValueTable VALUES ('value2', '{Guid.NewGuid()}'); commit;", con))
    		{
    			// This transaction will actually persist!
    			com.ExecuteNonQuery();
    		}
    	}
    	tx.Complete();
    }
