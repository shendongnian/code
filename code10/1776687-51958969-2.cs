    conn.Open();
    cmd.CommandText = cmdStr;
    cmd.CommandType = CommandType.StoredProcedure;
    
    //Base on sql you provided, it is no need for this part.
    /*
    SqlParameter vResult = new SqlParameter();
    vResult.ParameterName = "@vResult";
    vResult.Direction = ParameterDirection.Output;
    vResult.SqlDbType = System.Data.SqlDbType.???;
    vResult.Value = ???;
    cmd.Parameters.Add(vResult);
    */
    cmd.Parameters.Add("@param1", SqlDbType.VarChar).Value = TB_1.Text;
    cmd.Parameters.Add("@param2", SqlDbType.VarChar).Value = TB_2.Text;
    
    var result = cmd.ExecuteScalar();
    
    return Int32.Parse(result.ToString());
