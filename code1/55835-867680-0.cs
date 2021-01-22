    try
    {
      dc.Connection.Open();
      dc.Transaction = dc.Connection.BeginTransaction();
      dc.SubmitChanges();
    }
    finally
    {
      dc.Transaction.Rollback();
    }
