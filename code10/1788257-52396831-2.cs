    string inline = ConfigurationSettings.AppSettings["ConectionString"];
    using (SqlConnection toConect = new SqlConnection(inline))
    {
        using (SqlCommand cmd = new SqlCommand("DaReport", toConect))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
            cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                adp.Fill(ds);
                grid.DataSource = ds.Tables[0];
                grid.DataBind();
            }
        }
    }
