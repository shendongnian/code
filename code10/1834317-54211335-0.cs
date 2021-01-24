    int ExecuteNonQuery(string sql)
    {
        using(var con = new SqlConnection(connectionString))
        {
            using(var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return cmd.ExecueNonQuery();
            }
        }
    }
