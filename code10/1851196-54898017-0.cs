    var dt = new DataTable();
    
    using (SqlConnection con = new SqlConnection(mydatasource))
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select SRID, Name, Result from EditBatchResultsView where SRID = " + drpSRID.Text, con);
        SqlDataReader reader = cmd.ExecuteReader();
    
        // fill DataTable contents
        dt.Load(reader);
    
        // assign DataTable as data source instead
        radGridView1.DataSource = dt;
    }
    // DataBind goes here
