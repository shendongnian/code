    protected virtual void ExecuteScript(SqlConnection connection, string script)
    {
        string[] commandTextArray = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries); // See EDIT below!
        connection.Open();
        foreach (string commandText in commandTextArray)
        {
            if (commandText.Trim() == string.Empty) continue;
            SqlCommand command = new SqlCommand(script, connection);
            command.ExecuteNonQuery();
        }
        connection.Close();
    }
