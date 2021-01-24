    cmd.Parameters.Add("cur_c1", OracleType.Cursor).Direction = ParameterDirection.Output;
    cmd.Parameters.Add("user_name", OracleType.VarChar).Value = fname;
    cmd.Parameters.Add("user_pass", OracleType.VarChar).Value = pass;
    cmd.Parameters.Add("user_enid", OracleType.VarChar).Value = uname;
    cmd.Parameters.Add("bytes", OracleType.Blob).Value = bytes; // problem fixed
    cmd.Parameters.Add("iuser", OracleType.VarChar).Value = iuser;
    cmd.Parameters.Add("euser", OracleType.VarChar).Value = iuser;
