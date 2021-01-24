    public static void PerformTransaction(HttpRequestMessage req, string query, SqlConnection conn, TraceWriter log, SqlTransaction sqlTran, SqlCommand command)
    {
         try
            {
                command.ExecuteNonQuery();
                log.Info("Query Executed Successfully");
                sqlTran.Commit();
                log.Info("Transaction Commited Successfully");
            }
         catch
            {
                log.Info("Transaction Execution Error");
                sqlTran.Rollback();
                throw;
            }
    }
