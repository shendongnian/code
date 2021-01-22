    OracleCommand cmd = new OracleCommand("GetEmployeeDetails", conn);
    cmd.CommandType = CommandType.StoredProcedure;
    
       
    par = new OracleParameter("EmployeeId", OracleType.int32);
    par.Value = EmployeeId;
    par.Direction = ParameterDirection.Input;
    cmd.Parameters.Add(par);
    
    cmd.ExecuteNonQuery();
    
   
