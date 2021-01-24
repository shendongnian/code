    string query = "INSERT INTO test_table (column1, column2) VALUES (?column1,?column2);";
    cn.Open();
    using (MySqlCommand cmd = new MySqlCommand(query, cn))
    {
    	cmd.Parameters.Add("?column1", MySqlDbType.Int32).Value = 123;
    	cmd.Parameters.Add("?column2", MySqlDbType.VarChar).Value = "Test username";
    	cmd.ExecuteNonQuery();
    }
