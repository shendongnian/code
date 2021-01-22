    command.BeginExecuteNonQuery(delegate (IAsyncResult ar) {
       try { command.EndExecuteNonQuery(ar); }
       catch(Exception e) { /* log exception e */ }
       finally { sqlConnection.Dispose(); }
       }, null);
