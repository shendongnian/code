    DataSet ds;
    
    //Get Data
    using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create the command and set its properties.
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "GetMyData";
            command.CommandType = CommandType.StoredProcedure;
            
            ds = connection.ExecuteDataSet();
        }
    if(ds !=null && ds.Tables.Count > 0)
    {
        dg.DataSource = ds.Tables[0];
        // disable autogeneration of columns
        dg.AutoGenerateColumns = false;
        //Hide unecessary columns
        dg.Columns["a3"].Visible = false;
        dg.Columns["a4"].Visible = false;
    }
