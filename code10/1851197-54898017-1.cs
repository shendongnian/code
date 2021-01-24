    var dt = new DataTable();
    using (SqlConnection con = new SqlConnection(mydatasource))
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select SRID, Name, Result from EditBatchResultsView where SRID = @SRID", con);
        cmd.Parameters.Add("@SRID", SqlDbType.VarChar).Value = drpSRID.Text;
        SqlDataReader reader = cmd.ExecuteReader();
    
        // fill DataTable contents
        dt.Load(reader);
    
        // assign DataTable as data source instead
        radGridView1.DataSource = dt;
    }
