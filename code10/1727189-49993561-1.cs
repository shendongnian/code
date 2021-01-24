      SqlParameter param= new SqlParameter();
       param.ParameterName = "@parameter1";// Defining Name
       param.SqlDbType = SqlDbType.Int; // Defining DataType
       param.Direction = ParameterDirection.Input; // Setting the direction 
       param.Value = inputvalue;
