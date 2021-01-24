    //create a new datatable
    DataTable dt = new DataTable();
    
    //create the string that hold the query including token
    string query = "SELECT * FROM INFORMATION_SCHEMA.columns where table_name = @TableName";
    
    //create a new database connection
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        command.CommandType = CommandType.Text;
    
        //replace the token with the correct value
        command.Parameters.Add("@TableName", SqlDbType.VarChar).Value = DropDownList1.SelectedValue;
    
        //open the connection
        connection.Open();
        //load the data of the select into the datatable
        dt.Load(command.ExecuteReader());
    
        //bind the datatable to the gridview
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //but you can also skip the datatable and bind directly to the gridview
        GridView1.DataSource = command.ExecuteReader();
        GridView1.DataBind();
    }
