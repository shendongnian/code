    DataTable dt = new DataTable();
    using (SqlConnection con = new SqlConnection(strConnString))
    {
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.CommandType = CommandType.Text;
    
            con.Open();=
            SqlDataReader reader = cmd.ExecuteReader();
    
            if (reader.HasRows) // check if the reader contains rows
            {
                dt.Load(reader); // load to Datatable
    
                GridView1.DataSource = dt; // assign data source from DataTable
                GridView1.DataBind();
            }
        }
    }
