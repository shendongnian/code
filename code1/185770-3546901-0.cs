    using (SqlConnection conn = Connection.GetConnection())
    using (SqlCommand cmd = conn.CreateCommand())
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetComparisonModel";
        cmd.Parameters.Add("@Model_Id", SqlDbType.Int).Value = Model_Id;
        DataTable dt = new DataTable();
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            da.Fill(dt);
        }
        return dt;
    }
