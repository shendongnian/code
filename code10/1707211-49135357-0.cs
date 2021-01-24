    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new System.TimeSpan( 0, 15, 0 ) ))
        {
          try
          {
            for (int i=0; i<10000; i++)
            {
              dataContext.CallSP( i );
            }
            scope.Complete();
          }
          catch (Exception e)
          {
            log( e );
          }
        }
