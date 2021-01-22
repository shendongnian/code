    using (OdbcConnection connection = new OdbcConnection(connectionString))
    using (OdbcCommand command = connection.CreateCommand())
    {
        command.CommandText = commandText;
        command.CommandType = CommandType.StoredProcedure;
    
        command.Paremeters.Add("@KundenEmail", OdbcType.NChar, 50).Value = KundenEmail
    
        DataTable dataTable = new DataTable();
        connection.Open();    
        using (OdbcDataAdapter adapter = new OdbcDataAdapter(command))
        {
            adapter.Fill(dataTable);
        }
    }
