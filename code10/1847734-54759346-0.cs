    MySqlCommand update = dbConn.Connection.CreateCommand();
    try
    {
        update.CommandText = command;
        update.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
        update.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
        await update.ExecuteNonQueryAsync();
        return true;
    }
    finally
    {
        update.Dispose();
    }
