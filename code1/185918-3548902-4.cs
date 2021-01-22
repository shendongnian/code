    using (SqlConnection conn = new SqlConnection(connString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@ParamName", SqlDbType.Int);
        cmd.Parameters["@ParamName"].Value = newName;        
        conn.Open();
        string someReturn = (string)cmd.ExecuteScalar();        
    }
