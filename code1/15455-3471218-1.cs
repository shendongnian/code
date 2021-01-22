    using (SqlConnection con = new SqlConnection(Settings.Default.qlsdat_extensionsConnectionString))
    using (SqlCommand cmd = new SqlCommand(reportDataSource, con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = year;
        cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = start;
        cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = end;
        con.Open();
        DataSet dset = new DataSet();
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        {
            adapter.Fill(dset);
        }
        this.gridDataSource.DataSource = dset.Tables[0];
    }
