    using (cn = new SqlConnection(ConnectionString()))
    {
        cn.Open();
        using (cmd = new SqlCommand(sql, cn))
        {
            cmd.CommandType = CommandType.Text;
            object result = cmd.ExecuteScalar();
            numApprovals = result == null ? 0 : (int)result;
        }
    }
    return numApprovals;
