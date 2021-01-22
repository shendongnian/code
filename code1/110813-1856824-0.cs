    Transaction transaction = new Transaction( IsolationLevel.Chaos );
    try
    {
        using (var dc = new MyDataContext())
        {
           dc.Transaction = transaction;
           ...
           transaction.Commit();
        }
    }
    catch
    {
        transaction.Rollback();
    }
