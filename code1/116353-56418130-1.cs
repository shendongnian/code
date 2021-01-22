    /// <summary>
    /// Method to execute SQL Query statements with
    /// Transaction scope using isolation level to select read commited data
    /// </summary>
    /// <param name="query">SQL Query statement</param>
    /// <param name="connString">Connections String</param>
    internal DataTable SelectTransaction(string query, string connString)
    {
    	DataTable tableResult = null;
        SqlCommand cmd = null;
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        TransactionOptions tranOpt = new TransactionOptions();
        tranOpt.IsolationLevel = IsolationLevel.ReadCommitted;
        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, tranOpt))
        {
    		tableResult = new DataTable();
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tableResult);
                break;
            }
            catch (Exception ex)
            {
                scope.Dispose();
                throw new Exception("Erro durante a transação ao banco de Dados.", ex);
            }
            finally
            {
                if (null != adapter)
                {
                    adapter.Dispose();
                }
                if (null != cmd)
                {
                    cmd.Dispose();
                }
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            scope.Complete();
        }
    	return tableResult;
    }
