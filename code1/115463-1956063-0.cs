    string commandText= "update A set B = @BIN where C = D";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@BIN", SqlDbType.Binary);
        command.Parameters["@BIN"].Value = b;
    
        // command.Parameters.AddWithValue("@BIN ", b);
    
        try
        {
            connection.Open();
            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
