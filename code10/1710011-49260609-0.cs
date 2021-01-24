    using (SqlConnection con = new SqlConnection(connectionString)) {
        con.Open();
        using (SqlCommand cmd = new SqlCommand(query1, con)) {
            // cmd.CommandType = CommandType.xxxxx
            // add any parameters
            // Execute()
            cmd.CommandText = query2;
            // reset CommandType if needed
            // adjust parameters if needed
            // Execute()
            cmd.CommandText = query 3;
            // reset CommandType if needed
            // adjust parameters if needed
            // Execute()
        }
        con.Close();
    }
