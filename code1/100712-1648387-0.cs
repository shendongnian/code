    // run a stored procedure that takes a parameter
    	public void RunStoredProcParams()
    	{
    		SqlConnection conn = null;
    		SqlDataReader rdr  = null;
    
    		// typically obtained from user
    		// input, but we take a short cut
    		string custId = "FURIB";
    
    		Console.WriteLine("\nCustomer Order History:\n");
    
    		try
    		{
    			// create and open a connection object
    			conn = new 
    				SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
    			conn.Open();
    
    			// 1.  create a command object identifying
    			//     the stored procedure
    			SqlCommand cmd  = new SqlCommand(
    				"dbo.CustOrderHist", conn);
    
    			// 2. set the command object so it knows
    			//    to execute a stored procedure
    			cmd.CommandType = CommandType.StoredProcedure;
    
    			// 3. add parameter to command, which
    			//    will be passed to the stored procedure
    			cmd.Parameters.Add(
    				new SqlParameter("@CustomerID", custId));
    
    			// execute the command
    			rdr = cmd.ExecuteReader();
    
    			// iterate through results, printing each to console
    			while (rdr.Read())
    			{
    				Console.WriteLine(
    					"Product: {0,-35} Total: {1,2}",
    					rdr["ProductName"],
    					rdr["Total"]);
    			}
    		}
    		finally
    		{
    			if (conn != null)
    			{
    				conn.Close();
    			}
    			if (rdr != null)
    			{
    				rdr.Close();
    			}
    		}	
    	}
    }
    
        enter code here
