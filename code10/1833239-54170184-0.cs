    using (var com = new SqlCommand("insert into Messages values (@content)", con))
    {
        var param = new SqlParameter("@content", SqlDbType.NVarChar);
        param.Value = content;
        com.Parameters.Add(param);
        com.ExecuteNonQuery();
    }
