    DataTable dt = new DataTable();
    
    using(SqlConnection connection = new SqlConnection(ConnectionString))
    using(SqlCommand command = new SqlCommand("usp_CalcByProgFY_Weighted",connection))
    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
    {
    	command.Type = CommandType.StoredProcedure;
    	command.Parameters.Add(new SqlParameter("@FiscalYear", ListBox2.SelectedItem.Value.ToString()));
    	adapter.Fill(dt);
    }
    
    
    GridView2.DataSource = dt;
    GridView2.DataBind();
