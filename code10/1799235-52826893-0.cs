    public Customer GetCustomer(string name)
    {
        using (var connection = new SqlConnection(...))
        {
             var spName = "sp_Customers";
             var parameters = new 
             { 
                 Action = "Retrieve", 
                 CustomerName = name
             };
             var commandType = CommandType.StoredProcedure;
                  
             return connection.QuerySingleOrDefault<Customer>(spName, parameters, commandType: commandType); 
        }
    }
