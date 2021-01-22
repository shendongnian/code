    using System.Transactions; // Be sure to add a reference to System.Transactions.dll to your project.
        
           // ... in a method somewhere ...
           using (System.Transaction.TransactionScope trans = new TransactionScope())
           {
              using(YourDataContext context = new YourDataContext())
              {
                 context.ExecuteCommand("SET IDENTITY_INSERT MyTable ON");
        
                 context.ExecuteCommand("yourInsertCommand");
        
                 context.ExecuteCommand("SET IDENTITY_INSERT MyTable OFF");
              }
              trans.Complete();
           }
           // ...
