    // Get a cached Select Command
    SqlCeCommand command = this.selectCommand;
    // Tell it to match the first value you are searching for (having already set IndexName on the command 
    command.SetRange(DbRangeOptions.Match, new object[] { key }, null);
    // Read a single row
    SqlCeDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
    object value = null;
    // Read your value by column index.
    for (int i = 1; reader.Read(); i++)
    {
        value = reader[1];
    }
