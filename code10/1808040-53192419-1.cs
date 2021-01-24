    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    
    conn = new MySql.Data.MySqlClient.MySqlConnection();
    cmd = new MySql.Data.MySqlClient.MySqlCommand();
    
    conn.ConnectionString = strConnection;
    
    try
    {
        conn.Open();
        cmd.Connection = conn;
    
        cmd.CommandText = "INSERT INTO myTable VALUES(NULL, @number, @text)";
        cmd.Prepare();
    
        cmd.Parameters.AddWithValue("@number", 1);
        cmd.Parameters.AddWithValue("@text", "One");
    
        for (int i=1; i <= 1000; i++)
        {
            cmd.Parameters["@number"].Value = i;
            cmd.Parameters["@text"].Value = "A string value";
    
            cmd.ExecuteNonQuery();
        }
    }
    catch (MySql.Data.MySqlClient.MySqlException ex)
    {
        MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
