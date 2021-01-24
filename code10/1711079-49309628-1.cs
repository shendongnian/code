    string scriptText = File.ReadAllText(scriptFile, Encoding.Default);
    ExecuteBatch executeBatch = new ExecuteBatch();
    StringCollection commandTexts = executeBatch.GetStatements(scriptText);
    using (SqlConnection sqlConnection = new SqlConnection(conn))
    {
        sqlConnection.InfoMessage += SqlConnection_InfoMessage;
        sqlConnection.Open();
        for (int i = 0; i < commandTexts.Count; i++)
        {
            try
            {
                log.InfoFormat("Executing statement {0}", i + 1);
                string commandText = commandTexts[i];
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    log.Debug(commandText);
                    sqlCommand.CommandText = commandText;
                    sqlCommand.CommandTimeout = 300;
                    int r = sqlCommand.ExecuteNonQuery();
                    log.DebugFormat("{0} rows affected", r);
                }
            }
            catch (Exception ex)
            {
                log.Warn("Executing command failed", ex);
                try
                {
                    sqlConnection.Open();
                }
                catch (Exception ex2)
                {
                    log.Error("Cannot reopen connection", ex2);
                }
            }
        }
        sqlConnection.Close();
    }
