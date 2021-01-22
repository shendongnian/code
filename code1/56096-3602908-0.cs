    public string GetCustomerNumber(Guid id)
    {
       object accountNumber =  
              (object)DBSqlHelperFactory.ExecuteScalar(connectionStringSplendidCRM, 
                                    CommandType.StoredProcedure, 
                                    "spx_GetCustomerNumber", 
                                    new SqlParameter("@id", id));
        
        return String.Concat(accountNumber);
      
     }
