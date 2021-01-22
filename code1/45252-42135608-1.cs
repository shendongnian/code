    SqlConnection SqlConn = ...
    var sqlcomm = new SqlCommand("Validate", SqlConn);
    string returnValue = string.Empty;
    try
    {
        SqlConn.Open();
        sqlcomm.CommandType = CommandType.StoredProcedure;
        SqlParameter param = new SqlParameter("@a", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value = Username;
        sqlcomm.Parameters.Add(param);
        SqlParameter output = sqlcomm.Parameters.Add("@b", SqlDbType.VarChar);
        ouput.Direction = ParameterDirection.Output;
        
        sqlcomm.ExecuteNonQuery(); // This line was missing
        
        string retunvalue = output.Value.ToString();
        // ... the rest of code
    
    } catch (SqlException ex) {
        throw ex;
    }
