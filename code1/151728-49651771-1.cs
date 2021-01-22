	string sql = GetMultiStatementSqlString();
	string[] sqlStatements = sql.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
	using (OleDbConnection conn = new OleDbConnection(connStr))
	{
		conn.Open();
		OleDbTransaction transaction = conn.BeginTransaction();
		foreach (string statement in sqlStatements)
		{
			using (OleDbCommand cmd = new OleDbCommand(statement, conn, transaction))
			{
				cmd.ExecuteNonQuery();
			}
		}
		transaction.Commit();
	}
