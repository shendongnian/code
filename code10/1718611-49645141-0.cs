    using (var connection = new SqlCeConnection("connection_string"))
    {
    	connection.Open();
    	
        //Begin the transaction
    	using (var transaction = connection.BeginTransaction())
    	{
            //Create and fill-up master table data
			var paramMaster = new DynamicParameters();
			paramMaster.Add("@XXX", ...);
            ....
    
            //Insert record in master table. Pass transaction parameter to Dapper.
    		var affectedRows = connection.Execute("insert into OrdersMaster....", paramMaster, transaction: transaction);
    
            //Get the Id newly created for master table record.
            //If this is not an Identity, use different method here
            newId = Convert.ToInt64(connection.ExecuteScalar<object>("SELECT @@IDENTITY", null, transaction: transaction));
    
            //Create and fill-up detail table data
            //Use suitable loop as you want to insert multiple records.
            //for(......)
            foreach(OrderItem item in orderItems)
            {
				var paramDetails = new DynamicParameters();
				paramDetails.Add("@OrderMasterId", newId);
				paramDetails.Add("@YYY", ...);
            	....
    
	            //Insert record in detail table. Pass transaction parameter to Dapper.
    			var affectedRows = connection.Execute("insert into OrderDetails....", paramDetails, transaction: transaction);
    		}
            //Commit transaction
    		transaction.Commit();
    	}
    }
