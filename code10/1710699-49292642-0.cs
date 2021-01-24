     TransactionOptions transOption = new TransactionOptions();
     transOption.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
     using (TransactionScope scope = new 
     TransactionScope(TransactionScopeOption.Required, transOption))
     {
          foreach(var item in enter code here`list)
          {
               //your code
          }
     
        scope.Complete();
     }
