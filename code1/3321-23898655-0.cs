    foreach (var sqlBatch in commandText.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries))
    {
       sqlCommand.CommandText = sqlBatch;
       sqlCommand.ExecuteNonQuery();
    }
