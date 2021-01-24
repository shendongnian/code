    [HttpPut("{CustomerID}/{TableID}")]
    public void PutOrder([FromRoute] string CustomerID, [FromRoute] string TableID)
    {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            try
            {
                string s = "INSERT INTO orders (CustomerID, TableID) VALUES (@CustomerID, @TableID)";
                MySqlCommand command = new MySqlCommand(s, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@TableID", TableID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            { }
        }
    }
