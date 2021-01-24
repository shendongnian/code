    public int UpdateSQLDataTable(string connectionString, string TableName, DataTable dtSource)
    {
        try
        {
            using (SqlConnection sConn = new SqlConnection(connectionString))
            {
                sConn.Open();
                var transaction = sConn.BeginTransaction();
                try
                {
                    var command = sConn.CreateCommand();
                    command.Transaction = transaction;
                    command.CommandText = $"SELECT TOP 1 * FROM {TableName} WITH (NOLOCK)";
                    command.CommandType = CommandType.Text;
                    // timeoput of 5 minutes
                    command.CommandTimeout = 300;
                    SqlDataAdapter sAdp = new SqlDataAdapter(command);
                    SqlCommandBuilder sCMDB = new SqlCommandBuilder(sAdp);
                    int affectedRecords = sAdp.Update(dtSource);
                    transaction.Commit();
                    return affectedRecords;
                }
                catch (Exception /* exp */)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        catch (Exception exc)
        {
            Logger logger = new Logger();
            logger.Error(string.Format("connectionString: '{0}', TableName: '{1}'", connectionString, TableName), exc);
            return int.MinValue;
        }
    }
	
