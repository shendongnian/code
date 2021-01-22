    using (SqlDataAdapter da = new SqlDataAdapter(sql, GetConnectionString()))
    {
        da.SelectCommand.Parameters.Add("@title", SqlDbType.Text);
        da.SelectCommand.Parameters["@title"].Value = title;
        DataSet ds = new DataSet();
        da.Fill(ds, "Books");
        return ds.Tables["Books"];
    }
