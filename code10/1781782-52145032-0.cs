    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    
    DataSet output = new DataSet();
    adapter.Fill(output);
    GridViewOutput.DataSource = output.Tables[0]; // use DataTable index instead of its key
    GridViewOutput.DataBind(); // bind to grid
