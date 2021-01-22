    IDbTransaction dbTransaction = dbConnection.BeginTransaction();
    try
    {
      foreach (DataTable dataTable in dataSet.Tables)
      {
        string sql = "SELECT * FROM " + dataTable.TableName + " WHERE 0 = 1";
        SqlDataAdapter dataAdapter = new SqlDataAdapter (sql, dbConnection);
        dataAdapter.Update(dataSet, dataTable.TableName);
      }
    }
    catch
    {
      dbTransaction.Rollback();
      throw;
    }
    dbTransaction.Commit();
