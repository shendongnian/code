	using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
	{
		if (reader.Read())
		{
			// Bind your object using the reader.
		}
		else
		{
			// No row matched the query
		}
	}
