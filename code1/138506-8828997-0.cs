    string[] commands = currentQuery.Split(new string[] { "\nGO\r\n", "\nGO\n" }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string commandString in commands)
    {
        using (var command = new SqlCommand(commandString, connection))
        {
            command.ExecuteNonQuery();
        }
    }
