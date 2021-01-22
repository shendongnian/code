    using (SqlCommand cmd = new SqlCommand("MyStoredProcedure", cn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter parm = new SqlParameter("@pkid", SqlDbType.Int);
        parm.Value = 1;
        parm.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(parm);
    
        SqlParameter parm2 = new SqlParameter("@ProductName", SqlDbType.VarChar);
        parm2.Size = 50;
        parm2.Direction = ParameterDirection.Output; // This is important!
        cmd.Parameters.Add(parm2);
                    
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
