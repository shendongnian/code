	string sql = GetMultiStatementSqlString();
	string[] sqlStatements = sql.Split(';');
	using (OleDbConnection conn = new OleDbConnection(connStr))
	{
		conn.Open();
		OleDbTransaction transaction = conn.BeginTransaction();
		foreach (string statement in sqlStatements.Where(s => !string.IsNullOrWhiteSpace(s)))
		{
			using (OleDbCommand cmd = new OleDbCommand(statement, conn, transaction))
			{
				cmd.ExecuteNonQuery();
			}
		}
		transaction.Commit();
	}
