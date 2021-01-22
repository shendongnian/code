        var cmd = "UPDATE SomeTable SET Value = @Param1 WHERE ID = @ID";
        using (var connection = new SqlConnection("Connection String Here"))
        using (var command = new SqlCommand(cmd, connection))
        {
            command.Parameters.AddWithValue("@Param1", "NewValue");
            command.Parameters.AddWithValue("@ID", 1);
            connection.Open();
            command.ExecuteNonQuery();
        }
