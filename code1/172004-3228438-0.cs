    using(MySqlConnection conn = new MySqlConnection(connString))
    {
        MySqlCommand command = new MySqlCommand("spSomeProcedure;", conn);
        command.CommandType = System.Data.CommandType.StoredProcedure;
    
        // Add your parameters here if you need them
        command.Parameters.Add(new MySqlParameter("someParam", someParamValue));
    
        conn.Open();
        
        int result = (int)command.ExecuteScalar();
    }
