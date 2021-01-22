    using (var transaction = new System.Transactions.TransactionScope())
    {
      try
      {
        context.SaveChanges();
        transaction.Complete();
        context.AcceptAllChanges();
      }
      catch(OptimisticConcurrencyException e)
      {
        //Handle the exception
        context.SaveChanges();
      }
    }
