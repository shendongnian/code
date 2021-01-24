    using (SqlConnection conn = new SqlConnection())
    using (SqlCommand cmd = new SqlCommand(sql, conn))
    {
        cmd.Parameters.Add(new SqlParameter("ParamValue", someValue));
        da.Fill(ds);
    }
