	public static string ToReadableString(this IDbCommand command)
	{
		StringBuilder builder = new StringBuilder();
		if (command.CommandType == CommandType.StoredProcedure)
			builder.AppendLine("Stored procedure: " + command.CommandText);
		else
			builder.AppendLine("Sql command: " + command.CommandText);
		if (command.Parameters.Count > 0)
			builder.AppendLine("With the following parameters.");
		foreach (IDataParameter param in command.Parameters)
		{
			builder.AppendFormat(
				"     Paramater {0}: {1}",
				param.ParameterName,
				(param.Value == null ? 
				"NULL" : param.Value.ToString())).AppendLine();
		}
		return builder.ToString();
	}
