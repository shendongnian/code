    string cmdText = @"SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                       WHERE Table_Name = 'authorstab'";
    using(MySqlConnection cnn = GetMySqlConnection())
    using(MySqlCommand cmd = new MySqlCommand(cmdText, cnn))
    {
        DataTable dt = new DataTable();
        cnn.Open();
        using(MySqlDataReader reader = cmd.ExecuteReader())
            dt.Load(reader);
    }
