 	   //create connection and transaction do usual ADO.NET stuff
		   
		   SqlTransaction transaction = ... // existing transaction
            var existingConnection = transaction.Connection;
            var contextOwnsConnection = false;
           using (var db = new MyDbContext(existingConnection, contextOwnsConnection))
            {
			   db.Database.UseTransaction(transaction);
                //do something with db
            }
			
			// optionally do usual ADO.NET stuff  ....
			
			transaction.Commit();
