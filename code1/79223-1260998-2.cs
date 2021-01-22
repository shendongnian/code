    SqlConnection conn = null;
    SqlDataReader rdr  = null;
    conn = new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
    conn.Open();
    
    			// 1.  create a command object identifying the stored procedure
    SqlCommand cmd  = new SqlCommand("CustOrderHist", conn);
    
    			// 2. set the command object so it knows to execute a stored procedure
    cmd.CommandType = CommandType.StoredProcedure;
    
    			// 3. add parameter to command, which will be passed to the stored procedure
    cmd.Parameters.Add(new SqlParameter("@CustomerID", custId));
    
    			// execute the command
    rdr = cmd.ExecuteReader();
    
    			// iterate through results, printing each to console
    while (rdr.Read())
    {
    	Console.WriteLine("Product: {0,-35} Total: {1,2}",rdr["ProductName"],rdr["Total"]);
    }
