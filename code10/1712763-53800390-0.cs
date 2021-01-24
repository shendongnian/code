     SqlTransaction transaction = ... // your existing transaction
            var existingConnection = transaction.Connection;
            var contextOwnsConnection = false;
           using (var db = new MyDbContext(existingConnection, contextOwnsConnection))
            {
                //do something with db
            }
