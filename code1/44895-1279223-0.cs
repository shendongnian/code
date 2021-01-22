    using (TransactionScope ts = new TransactionScope())
    {
       try {
         // do db stuff here
       }
       finally {
         ts.Complete();
       }
    }
