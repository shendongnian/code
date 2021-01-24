    using (SqlConnection connection = new SqlConnection(...))
    {
        connection.Open();
        using (SqlTransaction ts = connection.BeginTransaction())
        using (SqlCommand cmd = new SqlCommand("PP_CreateSheet", connection, ts))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            .......
        }
        using (SqlCommand comm = new SqlCommand("PP_CreateNumber", connection, ts))
        {
            .....
            if (!int.TryParse(value, out parsedValue))
            {
                 lblError.Text = "Please enter only numeric values for number";
                 ts.Rollback();
                 return;
            }
            .....
        }
        // Before exiting from the SqlConnection using block call the 
        ts.Confirm();
    }
           
