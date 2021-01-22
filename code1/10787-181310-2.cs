    [WebMethod]
    void MyWSMethod(MyFields myFields)
    {/* code here*/}
    void InsertMyFields(MyFields myFields)
    {
      	using (SqlConnection connection = new SqlConnection(connectionString))
    	{
    		// Create the command and set its properties.
    		SqlCommand command = new SqlCommand();
    		command.Connection = connection;
    		command.CommandText = "AddMyFields";
    		command.CommandType = CommandType.StoredProcedure;
    
    		// Add the required input parameter
    		SqlParameter parameter1 = new SqlParameter();
    		parameter1.ParameterName = "@ReqField1";
    		parameter1.SqlDbType = SqlDbType.NVarChar;
    		parameter1.Direction = ParameterDirection.Input;
    		parameter1.Value = myFields.req1;
    
    		// Add the parameter to the Parameters collection. 
    		command.Parameters.Add(parameter1);
    		
    		// Add the input parameter and set its properties.
    		SqlParameter parameter2 = new SqlParameter();
    		parameter2.ParameterName = "@OptField1";
    		parameter2.SqlDbType = SqlDbType.NVarChar;
    		parameter2.Direction = ParameterDirection.Input;
    		parameter2.Value = myFields.opt1 ?? DBNull.Value; //null coalescing operator
    
    		// Add the parameter to the Parameters collection. 
    		command.Parameters.Add(parameter2);
    		
    		//.. rest of the code
    	}
    
    } 
