     SqlConnection sqlConnection = new SqlConnection(
         "blahblah;Asynchronous Processing=true;");
     SqlCommand command = new SqlCommand(
         "someProcedureName", sqlConnection);
     sqlConnection.Open();
     command.CommandType = CommandType.StoredProcedure;
     command.Parameters.AddWithValue("@param1", param1); 
     command.BeginExecuteNonQuery(delegate (IAsyncResult ar)
     {
       try
       {
        command.EndExecuteNonQuery(ar);
       }
       catch(Exception e)
       {
        // log exception e
       }
      finally
      {
        sqlConnection.Dispose();
      }
     }, null);
