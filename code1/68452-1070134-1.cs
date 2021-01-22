    bool saved = false;
    using (var transaction = new System.Transactions.TransactionScope())
    {
      try
      {
        context.SaveChanges();
        saved = true;
      }
      catch(OptimisticConcurrencyException e)
      {
        //Handle the exception
        context.SaveChanges();
      }
      finally
      {
        if(saved)
        {
          transaction.Complete();
          context.AcceptAllChanges();
        }
      }
    }
