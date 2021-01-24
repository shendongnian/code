    using (var connection = new OleDbConnection("connection string here"))
    using (var command = new OleDbCommand("update Cards set Count = Count - 1 where Type= ?", connection))
    {
        //have to guess at the OleDbType value. Use the actual column type and length from the database
        cmd.Parameters.Add("?", OleDbType.VarWChar, 10).Value = ct;
        connection.Open();
        command.ExecuteNonQuery();
    }
