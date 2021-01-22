    IDbTransaction dbTransaction = dbConnection.BeginTransaction();
    try
    {
      foreach (DataTable dataTable in dataSet.Tables)
        dataAdapter.Update(dataSet, dataTable.TableName);
    }
    catch
    {
      dbTransaction.Rollback();
      throw;
    }
    dbTransaction.Commit();
