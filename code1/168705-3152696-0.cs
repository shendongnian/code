    public void Export(Database dstDb)
    {
      try
      {
        using (DbConnection connection = dstDb.CreateConnection())
        {
            connection.Open();
            using (DbTransaction transaction = connection.BeginTransaction())
            {
                // Export all data here (insert into dstDb)
                ChangeStatus(MessageStatus.FINISHED);
                transaction.Commit();
            }
        }
      }
      catch (Exception exportEx)
      {
        LogError(exportEx);// create a log class for cross-cutting concerns 
            ChangeStatus(MessageStatus.ERROR);
            AddErrorDescription(exportEx.Message);
      
        throw; // throw preserves original call stack for debugging/logging
      }
    }
    private void ChangeStatus(MessageStatus status)
    {
      try
      {
        Status = status;
        srcDb.UpdateDataSet(drHeader.Table.DataSet, HEADERS,
            CreateHeaderInsertCommand(), CreateHeaderUpdateCommand(), null);
      }
      catch (Exception statusEx)
      {
       Log.Error(statusEx);
       throw;
      }
    }
