    using(SqlConnection conn = new SqlConnection("hard-coded connection string"))
    {
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // more init
            object scalar = cmd.ExecuteScalar();
            // process result
        }
     }
