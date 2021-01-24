    cmd.Parameters.Add("user_name", OracleType.VarChar).Value = fname;
    cmd.Parameters.Add("user_pass", OracleType.VarChar).Value = pass;
    cmd.Parameters.Add("user_enid", OracleType.VarChar).Value = uname;
    // user_name parameter used twice here, the exception thrown
    cmd.Parameters.Add("user_name", OracleType.Blob).Value = bytes; 
