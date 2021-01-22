       using (var scop = new System.Transactions.TransactionScope())
       {
           // all your test code and Asserts that access the database, 
           // writes and reads, from any class, ...
           // to commit at the very end of this block,
           // you would call
           // scop.Complete();  // ..... but don't and all will be rolled back
       }
