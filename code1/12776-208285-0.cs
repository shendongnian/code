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
        dgv.DataSource = ds.Tables[0];
        // disable autogeneration of columns
        dgv.AutoGenerateColumns = false;
        //Hide unecessary columns
        dgv.Columns["a3"].Visible = false;
        dgv.Columns["a4"].Visible = false;
    }
